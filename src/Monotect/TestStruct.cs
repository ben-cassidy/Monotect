// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;

public unsafe struct TestStruct
{
    public int Value;

    private string _managedField; // This should trigger the analyzer error

    private int _unmanagedField; // This should be fine

    private object _anotherManagedField; // This should also trigger the analyzer error

    // array should trigger it
    private int[] _managedArrayField;

    // fixed buffer should be fine
    private fixed int _unmanagedFixedBuffer[10];

    // pointer should be fine
    private int* _unmanagedPointerField;

    // pointer to managed type should be fine
    private string* _pointerToManagedTypeField;
    


}
