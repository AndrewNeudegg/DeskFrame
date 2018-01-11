# DeskFrame
###### A C#.net (4.6.1 targeted) desktop wallpaper replacement application, with plugin driven extensibility.
---  


## Minimum Required Tools
- Visual Studio 2017, or equivalent environment. 
- Git for updating source files.  


## Overview
This project is still under development, as such not all features required to make this an application that is friendly for all end users have been implemented. The core functionality is present, however is unoptimised and is fundamentally basic.  


## Project Status
- [x] Project builds with no errors under test environment.
- [x] Active and dynamic wallpaper replacement functions as desired.
- [x] Plugin system works, with development tools included in source.
- [ ] GUI for managing plugins has not been started.
- [ ] Application does not start on Windows start-up.
- [ ] Application does not gracefully handle crashes (desktop wallpaper remains after close).
- [ ] ShaderToy is unsupported at this time.
- [ ] Using the image plugin to play gifs as a desktop wallpaper is unoptimised.
- [ ] Project is in an unoptimised state.
- [ ] Project does not currently include an installer.


## Guide for developing plugins
Plugin development is as simple as referencing the `DeskFrameLib` project and implementing the `IDeskFrameView` interface. For sample code on valid implementations refer to the `ExampleFrames` project. Building this project will result in a Class Library (*.dll) that can be loaded by the plugin loader. A reference to `System.Windows.Forms` is required in order to create a `Form` object. This form then can be tested using the `Plugin Tester` project, which will iterate over all plugins found within its executing directory, loading each in sequence.  


## License 
Copyright 2018 Andrew Neudegg

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:  

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.  

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
