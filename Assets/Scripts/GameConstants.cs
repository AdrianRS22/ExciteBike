using UnityEngine;

public static class GameConstants
{
    /// <summary>
    ///  KeyCode para mover al personaje
    ///  *** Nota: hay que cambiar el keycode en Edit -> Project Settings -> Input Manager
    /// </summary>
    public const KeyCode RideKeyCode = KeyCode.X;

    /// <summary>
    ///  Axis del input manager que detecta movimientos en horizontal
    /// </summary>
    public const string AXIS_H = "Horizontal";

    /// <summary>
    ///  Axis del input manager que detecta movimientos en vertical y parametro vertical en el animator
    /// </summary>
    public const string AXIS_V = "Vertical";


}
