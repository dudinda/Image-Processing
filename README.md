# Image Processing 
[Microkernel Guide&Demo for WPF (SDI), Winforms (MDI/SDI/TDI) and Console processes](https://github.com/dudinda/MVPTemplate)

[![Build Status](https://dev.azure.com/dudin0da/Image%20Processing/_apis/build/status/Softenraged.Image-Processing?branchName=master)](https://dev.azure.com/dudin0da/Image%20Processing/_build/latest?definitionId=2&branchName=master)
[![Nuget](https://img.shields.io/badge/ImageProcessing.Microkernel.EntryPoint-1.1.0-orange)](https://www.nuget.org/packages/ImageProcessing.Microkernel.EntryPoint)
[![Nuget](https://img.shields.io/badge/ImageProcessing.Microkernel.MVP-1.1.0-orange)](https://www.nuget.org/packages/ImageProcessing.Microkernel.MVP)
[![Nuget](https://img.shields.io/badge/ImageProcessing.Microkernel.DIAdapter-1.1.0-orange)](https://www.nuget.org/packages/ImageProcessing.Microkernel.DIAdapter)
1. [Thesis](#Thesis)
2. [Solutions](#)
   - [General architecture of the transient process](#Architecture)
   - [Navigation by using a DI container](https://github.com/dudinda/Image-Processing/blob/master/Source/ImageProcessing.Microkernel.MVP/Controller/Implementation/AppController.cs#L45)
   - [Closures propagation by using a pipeline and event aggregator](https://github.com/dudinda/Image-Processing/blob/master/Source/ImageProcessing.App.PresentationLayer/Presenters/RgbPresenter.cs#L53)
   - [Linking a transient presenter and a view](https://github.com/dudinda/Image-Processing/blob/master/Source/ImageProcessing.Microkernel.MVP/Presenter/Implementation/BasePresenter.cs#L36)
   - [Partial mocks substitution via a DI container to test the internal infrastructure](https://github.com/dudinda/Image-Processing/blob/master/Tests/ImageProcessing.App.Integration/Monolith/UILayer/UIStartup.cs#L99)
   - [Reference a microkernel from a presentation to move a domain between processes](https://github.com/dudinda/Image-Processing/blob/master/Source/ImageProcessing.App.PresentationLayer/ImageProcessing.App.PresentationLayer.csproj#L60)
   - [Yielding a sequence to test a collection traverse order](https://github.com/dudinda/Image-Processing/blob/master/Tests/ImageProcessing.Utility.DataStructure.UnitTests/CaseFactory/BitMatrixCaseFactory.cs#L17)
3. [Benchmarks](#benchmarks-cpu)
4. [NuGet](#nuget)
***

## Thesis

<p>The application was originally developed as an R&D work.</p> 
<p>The original purpose was to research the possible advantages of grayscale images contrast optimization using a normal distribution regarding a uniform distribution. Two parameters such as the expectation and std allow to control relative luminance and contrast, respectively.</p>

<p align="center">
    <img src="https://github.com/dudinda/Image-Processing/blob/master/Tests/ImageProcessing.App.Integration/Code/Resources/Static/demo.gif?raw=true" width="600" height = "600" alt="application window">
    <p align="center">Fig. 1 - The main view and transient/signleton views as tabs. The opened affine transformation tab is a transient view. The settings tab is a singleton view. The frame is taken from <a href="https://i.imgur.com/h57F8D7.jpg">"Thomas the Tank Engine"</a> series and processed with the Grayscale->Inversion->Laplacian Operator 5x5->Inversion->Shear Rotation 20°->Bicubic Interpolation (0.2, 0.2)->Cyclic Translation (33, 33) (hold) [cpu] algorithm chain.</p>
</p>
<br/><br/>
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
    <p align="center">Fig. 4 - The histogram transformation by a normal distribution where µ = 90 and σ = 60.</p>
</p>

<p> To justify which image is better, regarding its contrast, one may use the definition of conditional variance: </p>
<p align="center">
    <img src="https://i.imgur.com/qa6QE4v.png" width="350" height = "150"">
</p>

<p> where [z1, z2] is an interval of relative luminance.</p>
<p> Splitting the interval [0, 255] to 16 subintervals we may now use the definition above. Since we define contrast as statistical scattering, the definition of conditional variance may show the level of contrast on each specified interval.</p>

<p align="center">
    <img src="https://i.imgur.com/OhGb6lI.png" alt="application window">
     <p align="center">Fig. 5 - Using the definition of conditional variance on 16 intervals of relative luminance.</p>
</p>

<p> Thus, one may conclude that a normal distribution may represent better result regarding a uniform distribution on a group of underexposed images.</p>

## Architecture

<p align="center">
   <img src="https://i.imgur.com/gWjiEET.png"  width="800" height = "800" alt="architecture">
   <p align="center">Fig. 6 - The process architecture.</p>
</p>

<p align="center">
   <img src="https://i.imgur.com/UBcybM9.png"  width="1400" height = "230" alt="metrics">
   <p align="center">Fig. 7 - The process code metrics.</p>
</p>

***

## Benchmarks [CPU]

[RGB Filters](https://github.com/Softenraged/Image-Processing/blob/master/Benchmarks/ImageProcessing.App.DomainLayer.Benchmark/LocalBenchmark.md#rgb-filters)

[Convolution](https://github.com/Softenraged/Image-Processing/blob/master/Benchmarks/ImageProcessing.App.ServiceLayer.Benchmark/LocalBenchmark.md#convolution)

***

## NuGet

[ImageProcessing.Microkernel.DIAdapter](https://www.nuget.org/packages/ImageProcessing.Microkernel.DIAdapter/)

[ImageProcessing.Microkernel.MVP](https://www.nuget.org/packages/ImageProcessing.Microkernel.MVP/)

[ImageProcessing.Microkernel.EntryPoint](https://www.nuget.org/packages/ImageProcessing.Microkernel.EntryPoint/)

