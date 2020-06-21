using System.Numerics;
using Box2D.NetStandard.Dynamics.Bodies;

namespace Box2D.NetStandard.Dynamics.Joints.Motor {
  public class MotorJointDef : JointDef {
    MotorJointDef() {
      Type             = JointType.MotorJoint;
      angularOffset    = 0.0f;
      maxForce         = 1.0f;
      maxTorque        = 1.0f;
      correctionFactor = 0.3f;
    }

    /// Initialize the bodies and offsets using the current transforms.
    public void Initialize(Body bA, Body bB) {
      BodyA = bA;
      BodyB = bB;
      Vector2 xB = BodyB.GetPosition();
      linearOffset = BodyA.GetLocalPoint(xB);

      float angleA = BodyA.GetAngle();
      float angleB = BodyB.GetAngle();
      angularOffset = angleB - angleA;
    }

    /// Position of bodyB minus the position of bodyA, in bodyA's frame, in meters.
    public Vector2 linearOffset;

    /// The bodyB angle minus bodyA angle in radians.
    public float angularOffset;

    /// The maximum motor force in N.
    public float maxForce;

    /// The maximum motor torque in N-m.
    public float maxTorque;

    /// Position correction factor in the range [0,1].
    public float correctionFactor;
  };
}