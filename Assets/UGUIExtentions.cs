using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public static class UGUIExtentions
{
    public static void BindCommand(this Button self, ICommand command)
    {
        Observable.EveryUpdate().Subscribe(_=>self.interactable = command.CanExecute()).AddTo(self);
        self.OnClickAsObservable().Subscribe(_ => command.Execute()).AddTo(self);
    }
}

public interface ICommand
{
    bool CanExecute();
    void Execute();
}

public class TestCommand0 : ICommand
{
    public Action OnExecute;

    public bool CanExecute()
    {
        return true;
    }

    public void Execute()
    {
        OnExecute?.Invoke();
    }
}
public class TestCommand1 : ICommand
{
    private bool flag = true;
    public bool CanExecute()
    {
        return flag;
    }

    public void Execute()
    {
        flag = false;
    }
}