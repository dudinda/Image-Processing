<img width="612" height="392" alt="ImageProcessing" src="" />
***Disclaimer**: The software provided in this repository was developed without the use of generative AI. Generative AI may only be used to verify grammatical correctness and syntax.*

<p>The application was originally developed as an R&D project between 2017 and 2019.</p> 
<p>The original purpose was to investigate the potential advantages of optimizing the contrast of grayscale images using a normal distribution compared with a uniform distribution. Two parameters - the expectation and standard derivation - allow to the relative luminance and contrast, respectively, to be controlled.</p>

# Image-Processing 

[Microkernel Guide&Demo for WPF (SDI), Winforms (MDI/SDI/TDI) and Console processes](https://github.com/dudinda/MVPTemplate)

1. [Overview](#overview)
   - [Hierarchy of modules](#hierarchy-of-modules)
   - [Navigation by using a DI container](https://github.com/dudinda/Image-Processing/blob/master/Source/ImageProcessing.Microkernel.MVP/Services/Controller/Implementation/AppController.cs#L45)
   - [Closures propagation by using a pipeline and event aggregator](https://github.com/dudinda/Image-Processing/blob/master/Source/ImageProcessing.App.Presentation/Presenters/RgbPresenter.cs#L53)
   - [Linking a transient presenter and a view](https://github.com/dudinda/Image-Processing/blob/master/Source/ImageProcessing.Microkernel.MVP/Presenter/Implementation/BasePresenter.cs#L36)
   - [Partial mocks substitution via a DI container to test the internal infrastructure](https://github.com/dudinda/Image-Processing/blob/master/Tests/ImageProcessing.App.Integration/Monolith/UI/Startup.cs#L61)
   - [Reference a microkernel from a presentation to move a domain between processes](https://github.com/dudinda/Image-Processing/blob/master/Source/ImageProcessing.App.Presentation/ImageProcessing.App.Presentation.csproj#L60)
2. [Managing Grayscale Images](#managing-grayscale-images)
3. [Created With](#created-with)
4. [Benchmarks](#benchmarks-cpu)
5. [NuGet](#nuget)
***

## Overview

<p align="center">
    <img src="https://github.com/dudinda/Image-Processing/blob/master/Tests/ImageProcessing.App.Integration/Code/Resources/Static/demo.gif?raw=true" width="600" height = "600" alt="application window">
    <p align="center">Fig. 1 - The main view and transient/signleton views are displayed as tabs. The opened affine transformation tab is a transient view. The settings tab is a singleton view. The frame is taken from the <a href="https://i.imgur.com/h57F8D7.jpg">"Thomas the Tank Engine"</a> series and processed using the following algorithm chain: Grayscale->Inversion->Laplacian Operator 5x5->Inversion->Shear Rotation 20°->Bicubic Interpolation (0.2, 0.2)->Cyclic Translation (33, 33) (hold) [cpu].</p>
</p>

### Hierarchy of modules
<p align="center">
   <img width="600" height="350" alt="hierarchy-of-modules" src="https://github.com/user-attachments/assets/d7dd6685-627f-492e-8105-8dfdb1692150" />
    <p align="center">Fig. 2 Hierarchy of modules.</p>
</p>

## Managing Grayscale Images

<p> Initially,  a group of underexposed images was chosen for experimental puproses. </p>
<p align="center">
    <img src="https://i.imgur.com/vvRrqaG.png" width="500" height = "400" alt="original underexposed image">
    <p align="center">Fig. 3 - The original underexposed image.</p>
</p>
<p> After optimization using  a uniform distribution, there is redundancy in bright areas of the relative luminance. However, using a normal distribution it's possible to minimize this effect and achieve better detail distinctiveness.</p>

<p align="center">
   <img src="https://i.imgur.com/zFM5TZl.png"  width="500" height = "400" alt="image transformed by uniform distribution">
   <p align="center">Fig. 4 - Histogram transformation using a uniform distribution.</p>
</p>

<p align="center">
    <img src="https://i.imgur.com/0txwVZ7.png" width="500" height = "400" alt="An image transformed by a normal distribution with the expectation = 90 and std = 60">
    <p align="center">Fig. 5 - Histogram transformation using a normal distribution, where µ = 90 and σ = 60.</p>
</p>

<p> To determine  which image has better contrast, one may use the definition of conditional variance: </p>
<p align="center">
    <img src="https://i.imgur.com/qa6QE4v.png" width="350" height = "150"">
</p>

<p> where [z1, z2] is an interval of relative luminance.</p>
<p> By splitting the interval [0, 255] to 16 subintervals, we can  use the definition above. Since contrast is defined as statistical scattering,  conditional variance can be used to measure the level of contrast within each specified interval.</p>

<p align="center">
    <img src="https://i.imgur.com/OhGb6lI.png" alt="application window">
     <p align="center">Fig. 6 - Using the definition of conditional variance over 16 intervals of relative luminance.</p>
</p>

<p> Thus, one may conclude that a normal distribution may produce better results than a uniform distribution for  a group of underexposed images.</p>

## Created With
[Windows Forms](https://github.com/dotnet/winforms)

[MetroModernUI](https://www.nuget.org/packages/metromodernui)

[LightInject](https://www.nuget.org/packages/Lightinject/), [Ninject](https://www.nuget.org/packages/ninject/)

[Microsoft.Extensions.Configuration](https://www.nuget.org/packages/microsoft.extensions.configuration/)

[NUnit](https://www.nuget.org/packages/nunit/), [NSubstitute](https://www.nuget.org/packages/nsubstitute/)

## Benchmarks [CPU]

[RGB Filters](https://github.com/Softenraged/Image-Processing/blob/master/Benchmarks/ImageProcessing.App.Domain.Benchmark/LocalBenchmark.md#rgb-filters)

[Convolution](https://github.com/Softenraged/Image-Processing/blob/master/Benchmarks/ImageProcessing.App.Domain.Benchmark/LocalBenchmark.md#convolution)

## NuGet

[ImageProcessing.Microkernel.DIAdapter](https://www.nuget.org/packages/ImageProcessing.Microkernel.DIAdapter/)

[ImageProcessing.Microkernel.MVP](https://www.nuget.org/packages/ImageProcessing.Microkernel.MVP/)

[ImageProcessing.Microkernel.EntryPoint](https://www.nuget.org/packages/ImageProcessing.Microkernel.EntryPoint/)

