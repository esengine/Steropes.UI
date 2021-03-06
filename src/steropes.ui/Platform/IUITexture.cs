﻿// MIT License
// Copyright (c) 2011-2016 Elisée Maurer, Sparklin Labs, Creative Patterns
// Copyright (c) 2016 Thomas Morgner, Rabbit-StewDio Ltd.
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
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Steropes.UI.Platform
{
  public interface IUITexture
  {
    Rectangle Bounds { get; }

    int Height { get; }

    string Name { get; }

    Texture2D Texture { get; }

    int Width { get; }

    IUITexture Rebase(Texture2D texture, Rectangle bounds, string name);
  }

  public class UITexture : IUITexture, IEquatable<UITexture>
  {
    public Rectangle Bounds { get; }

    public UITexture(Texture2D texture)
    {
      Texture = texture;
      Name = Texture?.Name ?? "";
      Bounds = new Rectangle(0, 0, Texture?.Width ?? 0, Texture?.Height ?? 0);
    }

    public UITexture(Texture2D texture, Rectangle bounds, string name = null)
    {
      Texture = texture;
      Bounds = bounds;
      Name = name ?? Texture?.Name ?? "";
    }

    public int Height => Bounds.Height;

    public string Name { get; }

    public Texture2D Texture { get; }

    public int Width => Bounds.Width;

    public virtual IUITexture Rebase(Texture2D texture, Rectangle bounds, string name)
    {
      return new UITexture(texture, bounds, name);
    }

    public static bool operator ==(UITexture left, UITexture right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(UITexture left, UITexture right)
    {
      return !Equals(left, right);
    }

    public bool Equals(UITexture other)
    {
      if (ReferenceEquals(null, other))
      {
        return false;
      }
      if (ReferenceEquals(this, other))
      {
        return true;
      }
      return Equals(Name, other.Name) && Equals(Bounds, other.Bounds);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj))
      {
        return false;
      }
      if (ReferenceEquals(this, obj))
      {
        return true;
      }
      if (obj.GetType() != this.GetType())
      {
        return false;
      }
      return Equals((UITexture)obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return (Name?.GetHashCode() ?? 0) ^ (37 * Bounds.GetHashCode());
      }
    }
  }
}