using Assets.Scripts.Nodes;
using UnityEngine;

namespace Nodes
{
    [NodeTint(51, 51, 51)]
    public class ExampleNode : ExecutableNode
    {
        public override void Execute()
        {
            Debug.Log("Executing Example Node");
        }

        public override bool IsFinished()
        {
            return true;
        }
    }
}