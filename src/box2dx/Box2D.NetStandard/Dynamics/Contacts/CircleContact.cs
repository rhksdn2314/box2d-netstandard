﻿/*
  Box2D.NetStandard Copyright © 2020 Ben Ukhanov & Hugh Phoenix-Hulme https://github.com/benzuk/box2d-netstandard
  Box2DX Copyright (c) 2009 Ihar Kalasouski http://code.google.com/p/box2dx
  
// MIT License

// Copyright (c) 2019 Erin Catto

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
*/

using System.Diagnostics;
using Box2D.NetStandard.Collision;
using Box2D.NetStandard.Collision.Shapes;
using Box2D.NetStandard.Common;
using Box2D.NetStandard.Dynamics.Fixtures;

namespace Box2D.NetStandard.Dynamics.Contacts
{
	public class CircleContact : Contact
	{
		public CircleContact(Fixture fixtureA, Fixture fixtureB)
			: base(fixtureA,0, fixtureB,0)
		{
			Debug.Assert(fixtureA.Type == ShapeType.Circle);
			Debug.Assert(fixtureB.Type == ShapeType.Circle);
		}

		public static Contact Create(Fixture fixtureA, Fixture fixtureB)
		{
			return new CircleContact(fixtureA, fixtureB);
		}

		public static void Destroy(ref Contact contact)
		{
			contact = null;
		}

		internal override void Evaluate(out Manifold manifold, in Transform xfA, in Transform xfB) {
			Collision.Collision.CollideCircles(out manifold,(CircleShape)m_fixtureA.Shape,xfA,(CircleShape)m_fixtureB.Shape,xfB);
		}
	}
}
