// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: iDataService.cs
/* FILE DESCRIPTION: An interface for any data processing. */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public interface iDataService
{
    bool SaveData<T>(string relativePath, List<T> data);

    T LoadData<T>(string relativePath);
}
