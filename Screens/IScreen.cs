using System;

namespace iku.Screens;

public interface IScreen
{
    void Load();
    void Update();
    void Draw();
    void Unload();
}
