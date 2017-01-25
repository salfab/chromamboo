# chromamboo
integration between bamboo+bitbucket and extensible color lights-based physical interfaces, such as backlit keyboards or chroma lamps

**contributors**
Please, read below for compiling instructions..

# Contribute or Compile from sources

## .Net
Chromamboo uses Kestrel to serve the web-based configuration editor. Kestrel's NuGet package does not automatically not copy the libuv.dll file in the output directory. This dll exists for both x64 or x86 compilations. For this reason, the compilation options are set to x86, and the x86 version of the libuv.dll is referenced within the project's files. This file is set to ``CopyAlways`` to the output directory, and should keep Kestrel running as long as the project is compiled for x86 CPUs.

If the project needs to be compiled in x64, please reference the appropriate libuv.dll version in the /packages/libuv folder.

## React
Use the npm script ``npm install --dev-only`` to retrieve the react-scripts necessary for building, hosting and starting the chromamboo-react application.

