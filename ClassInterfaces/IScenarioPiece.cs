﻿/*
 * This Interface is implemented by the Scenario class and the Stage class.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 04/05/2018
 * file name: IScenarioPiece.cs
 * version: 1.0
 */
namespace ClassInterfaces
{
    public interface IScenarioPiece
    {
        int ID { get; }
        string Name { get; }
        string Description { get; }
    }
}