using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Istate<T>
{
    void OnEnter(T t);
    void OnExercute(T t);
    void OnExit(T t);
}
