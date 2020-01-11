# Image Processing
Image filtration and contrast optimization.

<p>
The application was developed as the R&D work. It consists of 3 modules: RGB filtration, filtration using matrix convolution filters and a contrast optimization module.</p> 
<p>The original purpose was to research the possible advantages of grayscale images' contrast optimization using normal distribution regarding uniform distribution. Two parameters such as expectation and std allowing to control relative luminance and contrast, respectively.</p>

<p align="center">
    <img src="https://i.imgur.com/68lt7aP.png" width="600" height = "400" alt="application window">
    <p align="center">Fig. 1 - Main window.</p>
</p>

<p> Initially for experimental purposes was chosen a group of underexposed images. </p>
<p align="center">
    <img src="https://i.imgur.com/vvRrqaG.png" width="500" height = "400" alt="original underexposed image">
    <p align="center">Fig. 2 - The original underexposed image.</p>
</p>
<p> After optimization with uniform distribution, there is a redundancy in bright areas of relative luminance. However, using normal distribution it's possible to minimize this effect, achieving better details’ distinctiveness.</p>

<p align="center">
   <img src="https://i.imgur.com/zFM5TZl.png"  width="500" height = "400" alt="image transformed by uniform distribution">
   <p align="center">Fig. 3 - Histogram transformation by uniform distribution.</p>
</p>
                    
<p align="center">
    <img src="https://i.imgur.com/0txwVZ7.png" width="500" height = "400" alt="image transformed by normal distribution with expectation = 90 and std = 60">
    <p align="center">Fig. 4 - Histogram transformation by normal distribution where µ = 90 and σ = 60.</p>
</p>

<p> To justify which image is better, regarding its contrast one may use a definition of conditional variance: </p>
<p align="center">
    <img src="https://i.imgur.com/OYDHSrO.png" width="400" height = "200"">
</p>

<p> where [z1, z2] is an interval of relative luminance.</p>
<p> Splitting the interval [0, 255] to 16 subintervals we may now use the definition above. Since we define a contrast as statistical scattering, the definition of conditional variance may show the level of contrast on each specified interval.</p>

<p align="center">
    <img src="https://i.imgur.com/OhGb6lI.png" alt="application window">
     <p align="center">Fig. 5 - Using a definition of conditional variance on 16 intervals of relative luminance.</p>
</p>

<p> Thus, one may conclude that normal distribution represents better result regarding uniform distribution on a group of underexposed images.</p>

***

</p>To test the operation of this system, computer equipment was used with the following
technical characteristics: processor IntelCore i5 - 3450, 3.10 GHz, instruction set
- x64, RAM - 12 GB. The results are presented as an average of 10 tests for a frame of
size 1920x1680:</p>
<ol>
    <li>Grayscale filter: ~0.0282 seconds per frame</li>
    <li>Inversion filter:  ~0.0277 seconds per frame</li>
    <li>Binary filter: ~0.0713 seconds per frame</li>
<li>Histogram transformation using the specified distribution: ~0.0344 seconds per
    frame</li>
    <li>Image processing with matrix filter of radius 3: ~0.246 seconds per frame</li>
    <li>Image processing with matrix filter of radius 5: ~0.597 seconds per frame</li>
    <li>Image processing with matrix filter of radius 9: ~1.81 seconds per frame</li>
    </ol>




