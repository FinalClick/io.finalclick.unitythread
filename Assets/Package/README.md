# Final Click - Unity Main Thread Dispatcher

Run code safely on Unity’s main thread (for APIs like `UnityWebRequest`, `Instantiate`, etc.) with async/await support.  
Package: `io.finalclick.unitythread` → `https://github.com/FinalClick/io.finalclick.unitythread.git?path=/Assets/Package`

## Installation

Add via git url from package manager: `https://github.com/FinalClick/io.finalclick.unitythread.git?path=/Assets/Package`

## Usage

### Running synchronous functions

```csharp
int result = await UnityMainThread.Run(() => {
    Debug.Log("Running on main thread!");
    return 42;
});
```

### Running asynchronous functions

```csharp
await UnityMainThread.Run(async () => {
    await Task.Delay(1000);
    Debug.Log("Finished after 1 second on main thread.");
});
```

### Running asynchronous functions with return value

```csharp
string message = await UnityMainThread.Run(async () => {
    await Task.Delay(500);
    return "Hello from main thread!";
});
Debug.Log(message);
```
