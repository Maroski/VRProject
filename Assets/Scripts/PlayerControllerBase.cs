using System;

namespace Pilgrim.Controller
{
    abstract public class PlayerControllerBase
    {
        abstract public void OnClick();
        abstract public void OnHold(float delta);
        abstract public void OnRelease(float delta);
    }

}
