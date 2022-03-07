using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public static class DadoNovo {
    public static readonly byte[] RNGtable = { 58, 190, 171, 255, 89, 79, 13, 213, 151, 183, 22, 193, 145, 52, 14, 35, 97, 220, 80, 111, 131, 87, 216,
        73, 176, 215, 25, 17, 60, 157, 119, 23, 158, 30, 126, 201, 15, 93, 102, 187, 21, 12, 245, 132, 246, 36, 47, 137, 34, 136,
        168, 250, 153, 219, 18, 211, 77, 133, 184, 107, 223, 196, 221, 0, 192, 86, 236, 203, 2, 148, 92, 149, 1, 16, 51, 253, 249,
        244, 19, 24, 214, 135, 143, 95, 181, 50, 69, 130, 199, 155, 55, 101, 163, 224, 37, 194, 124, 81, 195, 83, 3, 210, 67, 208, 128,
        191, 179, 42, 59, 189, 129, 120, 160, 165, 43, 96, 39, 75, 114, 230, 109, 248, 74, 146, 242, 197, 122, 218, 32, 252, 118, 78, 33,
        26, 45, 139, 7, 170, 239, 5, 94, 103, 61, 57, 188, 222, 64, 206, 241, 254, 200, 65, 28, 71, 6, 198, 212, 141, 167, 38, 70, 66, 247,
        175, 233, 229, 227, 166, 228, 113, 4, 174, 182, 180, 251, 63, 84, 161, 115, 156, 162, 8, 185, 27, 117, 106, 76, 134, 231, 105, 178,
        112, 48, 125, 10, 154, 72, 150, 238, 110, 98, 147, 240, 204, 54, 40, 121, 138, 234, 226, 209, 152, 169, 29, 172, 123, 235, 108, 46,
        207, 142, 62, 140, 56, 85, 205, 186, 20, 9, 88, 11, 68, 159, 53, 225, 82, 99, 177, 44, 164, 91, 100, 144, 41, 217, 202, 90, 127, 116,
        232, 173, 104, 31, 237, 243, 49 };
    static byte[] index = new byte[2];
    static uint state;
    static bool initialized;
    // Start is called before the first frame update
    public static void SeedAuto() {
        index[0] = (byte)DateTime.Now.Ticks;
        index[1] = (byte)(Process.GetCurrentProcess().Id / 4);
    }

    static byte RNGiego() {
        if (!initialized) { 
            SeedAuto();
            initialized = true;
        }
        index[0]++;
        index[1]--;
        if (index[1] == 250) index[1] = 247;
        return RNGtable[RNGtable[index[0]] ^ RNGtable[index[1]]];
    }

    public static float FRandom() {
        return (RNGiego() / 255f);
    }

    public static int RandomNext(int min, int max) {
        int rngMult = max - min;
        int rngAdd = min;
        rngMult = Mathf.RoundToInt(rngMult * FRandom()) + rngAdd;
        return rngMult;
    }
}
