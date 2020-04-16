# Image Processing
Image filtration and contrast optimization.

1. [Thesis](#Thesis)
2. [Architecture](#Architecture)
3. [Benchmarks](#Benchmarks)

***

## Thesis

<p>The application was developed as the R&D work.</p> 
<p>The original purpose was to research the possible advantages of grayscale images contrast optimization using a normal distribution regarding a uniform distribution. Two parameters such as the expectation and the std allow to control relative luminance and contrast, respectively.</p>

<p align="center">
    <img src="https://i.imgur.com/dUMCOy1.png" width="700" height = "400" alt="application window">
    <p align="center">Fig. 1 - The main window.</p>
</p>

<p> Initially, for experimental purposes was chosen a group of underexposed images. </p>
<p align="center">
    <img src="https://i.imgur.com/vvRrqaG.png" width="500" height = "400" alt="original underexposed image">
    <p align="center">Fig. 2 - The original underexposed image.</p>
</p>
<p> After an optimization with a uniform distribution, there is a redundancy in bright areas of relative luminance. However, using a normal distribution it's possible to minimize this effect, achieving better details’ distinctiveness.</p>

<p align="center">
   <img src="https://i.imgur.com/zFM5TZl.png"  width="500" height = "400" alt="image transformed by uniform distribution">
   <p align="center">Fig. 3 - The histogram transformation by a uniform distribution.</p>
</p>
                    
<p align="center">
    <img src="https://i.imgur.com/0txwVZ7.png" width="500" height = "400" alt="An image transformed by a normal distribution with the expectation = 90 and std = 60">
    <p align="center">Fig. 4 - The histogram transformation by the normal distribution where µ = 90 and σ = 60.</p>
</p>

<p> To justify which image is better, regarding its contrast, one may use a definition of conditional variance: </p>
<p align="center">
    <img src="https://i.imgur.com/qa6QE4v.png" width="350" height = "150"">
</p>

<p> where [z1, z2] is an interval of relative luminance.</p>
<p> Splitting the interval [0, 255] to 16 subintervals we may now use the definition above. Since we define contrast as statistical scattering, the definition of conditional variance may show the level of contrast on each specified interval.</p>

<p align="center">
    <img src="https://i.imgur.com/OhGb6lI.png" alt="application window">
     <p align="center">Fig. 5 - Using a definition of conditional variance on 16 intervals of relative luminance.</p>
</p>

<p> Thus, one may conclude that normal distribution represents better result regarding uniform distribution on a group of underexposed images.</p>

***

## Architecture

<p align="center">
   <img src="https://i.imgur.com/wxDianc.png"  width="800" height = "400" alt="architecture">
   <p align="center">Fig. 6 - The architecture of the application.</p>
</p>

***

## Benchmarks [CPU]

[RGB Filters](https://github.com/Softenraged/Image-Processing/blob/master/Benchmarks/ImageProcessing.App.DomainModel.Benchmark/LocalBenchmark.md#rgb-filters)

[Convolution](https://github.com/Softenraged/Image-Processing/blob/master/Benchmarks/ImageProcessing.App.ServiceLayer.Benchmark/LocalBenchmark.md#convolution)

