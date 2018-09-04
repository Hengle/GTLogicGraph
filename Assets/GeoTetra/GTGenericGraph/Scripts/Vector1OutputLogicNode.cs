﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeoTetra.GTGenericGraph
{
    [LogicNodeType("Vector1Output")]
    public class Vector1OutputLogicNode : LogicNode
    {
        //output id 1 - change to attibute?
        //[LogicOutput]
        public event Action<float> output;

        [SerializeField] 
        private float _value;

        public float Value
        {
            get { return _value; }
        }

        //input id 0
        //[LogicInput]
        public void SetValue(float value)
        {
            _value = value;
            if (output != null) output(_value);
        }
        
        public override Action<float> InputSlot(int id)
        {
            switch (id)
            {
                case 0:
                    return SetValue;
            }

            return null;
        }
        
        public override Action<float> OutputSlot(int id)
        {
            switch (id)
            {
                case 1:
                    return output;
            }

            return null;
        }
    }
}