# Changelog

## [1.0.0] - 2025-09-07

### Added

- `UnityMainThread.Run(Action)` Run synchronous functions on the main thread.
- `UnityMainThread.Run(Func<Task>)` Run asynchronous functions on the main thread.
- `UnityMainThread.Run(Func<Task<T>>)` Run asynchronous functions with a return value on the main thread.
