# evercraft-dotnet-orleans
Using the [Evercraft Kata](https://github.com/PuttingTheDnDInTDD/EverCraft-Kata/) to explore the [Microsoft Orleans](https://github.com/dotnet/orleans) actor model framework.

## Links
* [Orleans Documentation](https://dotnet.github.io/orleans/Documentation/index.html)
* [Virtual Actor Model](https://www.microsoft.com/en-us/research/publication/orleans-distributed-virtual-actors-for-programmability-and-scalability/?from=http%3A%2F%2Fresearch.microsoft.com%2Fapps%2Fpubs%2Fdefault.aspx%3Fid%3D210931)

## Why?
> Orleans builds on the developer productivity of .NET and brings it to the world 
> of distributed applications, such as cloud services. Orleans scales from a single 
> on-premises server to globally distributed, highly-available applications in the cloud. 
> Orleans takes familiar concepts like objects, interfaces, async/await, and try/catch and 
> extends them to multi-server environments. As such, it helps developers experienced with 
> single-server applications transition to building resilient, scalable cloud services and 
> other distributed applications.

Orleans promises to abstract away the "hard parts" of the actor models we see implemented in 
Akka and Elixir - namely, managing Supervision Trees as the application scales beyond a single server.

It also looks interesting from a Microservices perspective, as Orleans has the concepts of 
[Stateless Worker Grains](https://dotnet.github.io/orleans/Documentation/grains/stateless_worker_grains.html) 
and [Grain Services](https://dotnet.github.io/orleans/Documentation/grains/grainservices.html) that 
could allow the creation of easily-scalable computation services.