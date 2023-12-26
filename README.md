# Windows 11 Print Spike

Sample repository used to demonstrate a bug in Windows 11 after the 22H2 update. The bug causes WPF applications to use the UWP print dialog as a default when printing objects. However, the UWP print dialog does not honor print settings when these are set programmatically.

## Running

**Tools Needed**
Visual Studio 2022

**Steps**
1. Open the solution
2. Run the application
3. Set print options in the UI
4. Click Print
5. Observe UWP dialog options to confirm it doesn't honor programmatic options
