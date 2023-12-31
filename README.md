﻿# AV00 Shared Library
Shared code models and utilities for all AV00 projects.

## Info
Details can be found here in the project plan readme
[AV00 Primary Repo](https://github.com/kelceydamage/AV00)

## Making New Models For Use As Events
The base object sent between services over ZeroMQ is an `Event<T>` (`IEvent`). Event is a simple carrier object capable of serializing and deserializing itself and an `EventModel` (`IEventModel`) it's carrying. You can see the documentation for `Event` here: [AV00 Transport Repo](https://github.com/kelceydamage/AV00-transport)

Here is the template to make a new shared EventModel.
```c#
namespace AV00_Shared.Models
{
    public class MyNewEventModel : EventModel, IEventModel
    {
        public string MyNewProperty { get => myNewProperty; }
        private readonly string myNewProperty;

        public MyNewEventModel(string ServiceName, string MyNewProperty, Guid? Id = null, string? TimeStamp = null) : base(ServiceName, Id, TimeStamp)
        {
            myNewProperty = MyNewProperty;
        }
```

A new event model must descend from EventModel. Implementing IEventModel is a given, but we add it for explicit reference. An EventModel contains three intrinsic properties: `Id (Guid)`, `ServiceName (string`, `TimeStamp (string)`. Only `ServiceName` is required by the constructor. Both `Id` and `TimeStamp` will be auto-generated by the EventModel parent if they are left `null`.

For general use we can likely simplify this constructor into the following.
```c#
        public MyNewEventModel(string ServiceName, string MyNewProperty) : base() { myNewProperty = MyNewProperty; }
```

If this model will be used with the Entity Framework, an explicit constructor with all values required and none set to nullable, will be needed in addition to the base constructor.
```c#
        // Entity Framework constructor. Used for creating an object from SQL.
        public MyNewEventModel(string ServiceName, string MyNewProperty, Guid Id, string TimeStamp) : base(ServiceName, Id, TimeStamp)
        {
            myNewProperty = MyNewProperty;
        }
```
