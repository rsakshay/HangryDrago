using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTypes {

    public static class Constants
    {
        public const float PLAYER_Z = -3.0F;

        public const string PLAYER_TAG = "Player";

        public const float FURTHEST_CAMERA_LEFT = -5.0f;
        public const float FURTHEST_CAMERA_RIGHT = 110.32f;
        public const float FURTHEST_CAMERA_UP = 16.5f;
        public const float FURTHEST_CAMERA_DOWN = 1.71f;

        public enum EnemyStates
        {
            Resting,
            Attacking,
            Resseting
        }

        public enum TypesOfFruit
        {
            Cherry,
            Plumb,
            Pear,
            Melon
        }

        public static int FindIndexforFruit(TypesOfFruit fruit)
        {
            switch(fruit)
            {
                case TypesOfFruit.Cherry:
                    return 0;

                case TypesOfFruit.Plumb:
                    return 1;

                case TypesOfFruit.Pear:
                    return 2;

                case TypesOfFruit.Melon:
                    return 3;
            }

            return -1;
        }
    }
}
