# Batch Process

A user interface to configure batch processing of files.

## Requirements

- .NET Framework 4.6.1

## Configuration

### Executable

Full path to the executable to launch for each file.

### Parameters

Command line arguments to pass to the executable, in addition to the current file path.

The following replacement tags can be used:

- `<filepath>`: Full path to the current file. Ex: `c:\folder\file.txt`
- `<filename>`: File name of the current file. Ex: `file.txt`
- `<name>`: Name of the current file, no extension. Ex: `file`
- `<ext>`: Extension of the current file. Ex: `txt`
- `<folder>`: Full path to the current file's folder. Ex: `c:\folder`

### Run in parallel

Launch the executable in parallel for every file.

### Show window

Show or hide the console window.

## License

MIT License

Copyright (c) 2018 Hugues Valois

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.



