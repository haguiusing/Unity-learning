[Entity Component System与Entity Component-CSDN博客](https://blog.csdn.net/alexhu2010q/article/details/124526088)

## 什么是ECS？
- Entity（实体）：在ECS架构中表示“一个单位”，可以被ECS内部标识，可以挂载若干组件。
- Component（组件）：挂载在Entity上的组件，负载实体某部分的属性，是纯数据结构不包含函数。
- System（系统）：纯函数不包含数据，只关心具有某些特定属性（组件）的Entity，对这些属性进行处理。

## 什么是EC?
EC框架跟ECS非常类似，无非ECS框架里，Component只负责存Data，而EC框架里，Component除了存Data，还要存Behavior相关的逻辑代码。

## Unity和UE4里用的是EC还是ECS?


