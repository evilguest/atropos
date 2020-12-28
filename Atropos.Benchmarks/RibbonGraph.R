list.of.packages <- c("ggplot2", "dplyr", "gdata", "tidyr", "grid", "gridExtra", "stringr", "Rcpp", "R.devices")
new.packages <- list.of.packages[!(list.of.packages %in% installed.packages()[,"Package"])]
if(length(new.packages)) install.packages(new.packages, lib = Sys.getenv("R_LIBS_USER"), repos = "https://cran.rstudio.com/")

library(ggplot2)
library(dplyr)
library(gdata)
library(tidyr)
library(grid)
library(gridExtra)
library(R.devices)
library(stringr)

ends_with <- function(vars, match, ignore.case = TRUE) {
  if (ignore.case)
    match <- tolower(match)
  n <- nchar(match)

  if (ignore.case)
    vars <- tolower(vars)
  length <- nchar(vars)

  substr(vars, pmax(1, length - n + 1), length) == match
}

ggsaveNice <- function(fileName, p, ...) {
  suppressGraphics(ggsave(fileName, plot = p, ...))
}

args <- commandArgs(trailingOnly = TRUE)
resPath <- "./BenchmarkDotNet.Artifacts/results"

files <- if (length(args) > 0) args else list.files(resPath)[list.files(resPath) %>% ends_with("-report.csv")]

for (file in files) {
  title <- gsub("-report.csv", "", basename(file))
  cat(paste0("Processing file: ", file, "\n"))
  report <- read.csv(paste(resPath, file, sep="/"), sep=",")
  report$Mean <- as.numeric(gsub(",","", str_sub(report$Mean, end=-5)))
  report$Error <- as.numeric(gsub(",","", str_sub(report$Error, end=-5)))
  report$Allocated <- as.numeric(str_sub(report$Allocated, end=-2))

  plot <- ggplot(report, aes(x=Size, y=Mean, ymin=Mean-Error, ymax=Mean+Error, color=Method)) +
    labs(y="Time") +
    geom_ribbon(aes(fill=Method, alpha=0.5), linetype=0, show.legend=FALSE) +
    geom_line(size=1) +
    geom_point(size=1.5) +
    scale_x_continuous(trans="log2") 
  cat(paste0("Saving ", title, ".png\n"))
  ggsaveNice(paste0(title, ".png"), plot, width=8, height=5, dpi=150)
  aplot <- ggplot(report, aes(x=Size, y=Allocated, color=Method)) +
    geom_line(size=1) +
    geom_point(size=1.5) +
    scale_x_continuous(trans="log2") 
  cat(paste0("Saving ", title, ".alloc.png\n"))
  ggsaveNice(paste0(title, ".alloc.png"), aplot, width=8, height=5, dpi=150)
}