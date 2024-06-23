namespace Get.UI.Data;
readonly struct Disposable(Action OnDispose) : IDisposable
{
    public void Dispose() => OnDispose();
}