***Disclaimer**: The software provided in this repository was developed without the use of generative AI. Generative AI may only be used to verify grammatical correctness and syntax.*

<p>The application was originally developed as an R&D project between 2017 and 2019.</p> 
<p>The original purpose was to investigate the potential advantages of optimizing the contrast of grayscale images using a normal distribution compared with a uniform distribution. Two parameters - the expectation and standard derivation - allow to the relative luminance and contrast, respectively, to be controlled.</p>

[Microkernel Guide&Demo for WPF (SDI), Winforms (MDI/SDI/TDI) and Console processes](https://github.com/dudinda/MVPTemplate)

# Image-Processing 

1. [Overview](#overview)
   - [Hierarchy of modules](#hierarchy-of-modules)
2. [Microkernel](#microkernel)
   - [Navigation by using a DI container](#navigation-by-using-a-di-container)
   - [Linking a transient presenter and a view](#linking-a-transient-presenter-and-a-view)
3. [Application](#application)
   - [Closures propagation by using a pipeline and event aggregator](#closures-propagation-by-using-a-pipeline-and-event-aggregator)
   - [Reference a microkernel from a presentation to move a domain](#reference-a-microkernel-from-a-presentation-to-move-a-domain)
4. [Integration tests](#integration-tests)
   - [Partial mocks and a DI container](#partials-mocks-and-a-di-container)
5. [Managing Grayscale Images](#managing-grayscale-images)
6. [Created With](#created-with)
7. [Benchmarks](#benchmarks-cpu)
8. [NuGet](#nuget)
***

## Overview

The application consists of a desktop window with a main viewport implemented as a `PictureBox` where the sequentially transformed images are rendered. The menu on the top allows users to generate views, which are appended to the bottom. The toolbar below the menu allows to undo or redo transformations, restore the originally loaded image, and capture a custom area within the viewport. Two trackbars apply rotation or scaling transformations without rendering an image. 

Each generated view produces a tab below the viewport, allowing users to apply algorithms or manage related parameters.

<p align="center">
    <img src="https://github.com/dudinda/Image-Processing/blob/master/Tests/ImageProcessing.App.Integration/Code/Resources/Static/demo.gif?raw=true" width="600" height = "600" alt="application window">
    <p align="center">Fig. 1 - The main view and transient/singleton views are displayed as tabs. The opened affine transformation tab is a transient view. The settings tab is a singleton view. The frame is taken from the <a href="https://i.imgur.com/h57F8D7.jpg">"Thomas the Tank Engine"</a> series and processed using the following algorithm chain: <code>Grayscale->Inversion->Laplacian Operator 5x5->Inversion->Shear Rotation 20°->Bicubic Interpolation (0.2, 0.2)->Cyclic Translation (33, 33)</code> (hold) [cpu].</p>
</p>


### Hierarchy of modules

The project is built around two major namespaces: `Microkernel` and `App` .  As discussed below, this hierarchy allows an application to scale vertically, from views to presenters to service/provider/factory components, and horizontally, by adding subsystems within these categories. Decoupling the UI does not limit the application to static forms; it also allows to apply XML/XAML-based interfaces or console applications to use the same set of event handlers and domain modules. Additionally, as demonstrated in this application, the hierarchy supports comprehensive integration testing of any component, including the verification of incoming arguments and function calls.

<p align="center">
   <img width="600" height="350" alt="hierarchy-of-modules" src="https://github.com/user-attachments/assets/d7dd6685-627f-492e-8105-8dfdb1692150" />
    <p align="center">Fig. 2 Hierarchy of modules.</p>
</p>

## Microkernel

Following the microkernel concept, the first step is to introduce a registry that manages the lifecycle of its components and resolves them on demand. In a programming language, a dependency injection (DI) container can serve as this registry, mapping specific implementations to their interfaces or base classes. Since multiple container implementations may be available, the namespace introduces `IContainerAdapter`, which provides access to the APIs of the underlying microkernel implementations.

Furthermore, the module provides a fluent `IComponentProvider` builder that allows clients to register components at the application level within the `IStartup` implementation. The `IAppController` interface is exposed as a singleton through the static property. Additionally, the application controller composes the `IComponentProvider`, and `IEventAggregator` . During initialization, The component provider registers itself, the event aggregator, and the application controller. The aggregator connects presenters and views, providing a mechanism of publishing domain events using a unicast and broadcast messaging.

### Navigation by using a DI Container

To build a fluent workflow with desktop forms, it is convenient to provide a common routing mechanism. The router acts as a generator, resolving the dependency tree for specific components.

The first generator is `ILoggerFactory`, from the `Microsoft.Extensions.Logging.Abstractions` namespace, which creates logging categories for a transient presenter. This presenter, which assembles the services and logger, is a base class implementing the `IPresenter` interface.



### Linking a Transient Presenter and a View


## Application

### Closures Propagation by using a Pipeline and Event Aggregator
### Reference a Microkernel from a Presentation  to Move a Domain

## Integration tests

### Partials Mocks and a DI Container

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

<p> where <code>[z1, z2]</code> is an interval of relative luminance.</p>
<p> By splitting the interval `[0, 255]` to 16 subintervals, we can  use the definition above. Since contrast is defined as statistical scattering,  conditional variance can be used to measure the level of contrast within each specified interval.</p>

<p align="center">
    <img src="https://i.imgur.com/OhGb6lI.png" alt="application window">
     <p align="center">Fig. 6 - Using the definition of conditional variance over 16 intervals of relative luminance.</p>
</p>

<p> Thus, one may conclude that a normal distribution may produce better results than a uniform distribution for  a group of underexposed images.</p>

## Created With
[.NET 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48), [netstandard2.0](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0)

[Windows Forms](https://github.com/dotnet/winforms)

[MetroModernUI](https://www.nuget.org/packages/metromodernui)

[LightInject](https://www.nuget.org/packages/Lightinject/), [Ninject](https://www.nuget.org/packages/ninject/)

[Serilog](https://www.nuget.org/packages/serilog/), [Microsoft.Extensions.Logging](https://www.nuget.org/packages/microsoft.extensions.logging/)

[Microsoft.Extensions.Configuration](https://www.nuget.org/packages/microsoft.extensions.configuration/)

[Microsoft.Extensions.Caching.Memory](https://www.nuget.org/packages/microsoft.extensions.caching.memory/)

[NUnit](https://www.nuget.org/packages/nunit/), [NSubstitute](https://www.nuget.org/packages/nsubstitute/)

[MessageLoop.Common](https://www.nuget.org/packages/messageloop.common/)

## Benchmarks [CPU]

[RGB Filters](https://github.com/Softenraged/Image-Processing/blob/master/Benchmarks/ImageProcessing.App.Domain.Benchmark/LocalBenchmark.md#rgb-filters)

[Convolution](https://github.com/Softenraged/Image-Processing/blob/master/Benchmarks/ImageProcessing.App.Domain.Benchmark/LocalBenchmark.md#convolution)

## NuGet

[ImageProcessing.Microkernel.MVP](https://www.nuget.org/packages/ImageProcessing.Microkernel.MVP/)