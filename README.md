# WCFLimit

WCFLimit uses .NET Framework 4.7.2 and has 2 services - a Throttled and a so-called Unthrottled service and compares the two's stats

All the tests will:
1. Blast calls at the service
2. The service will then attempt to reply back to these calls
3. A metric will be provided once all tasks are completed.

# Usage

1. Make sure to build both the TestThrottledService as well as the TestService
2. In the WCFLimits project, make sure both are updated under "Connected Services"
3. Run!

You can modify the following values for some more information:
1. callLimit (In WCFLimits | Program.cs)
2. Feel free to play with the binding behaviors.
