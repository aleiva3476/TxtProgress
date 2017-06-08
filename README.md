# TxtProgress
Simple progressbar for console applications

Only has three static methods.

Example:

```
TxtProgress.Start("Job title", numSteps);

while(...)
{
  TxtProgress.Step();
  ...
  Do your job
  ...
}

TxtProgress.End();
```
