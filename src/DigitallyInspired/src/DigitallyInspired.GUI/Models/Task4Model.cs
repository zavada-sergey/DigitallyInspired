using DigitallyInspired.GUI.Abstractions.Models;
using System.Linq;
using System.Windows.Media.Media3D;

namespace DigitallyInspired.GUI.Models
{
    public class Task4Model : BaseTaskModel
    {
        public Point3DCollection GetCoordinatesForBoundingBox(Point3DCollection positions)
        {
            const double distance = 10.0;
            const double half = 2.0;

            var minX = positions.Min(x => x.X);
            var minY = positions.Min(x => x.Y);
            var minZ = positions.Min(x => x.Z);
            var maxX = positions.Max(x => x.X);
            var maxY = positions.Max(x => x.Y);
            var maxZ = positions.Max(x => x.Z);

            return new Point3DCollection
            {
                //Upper
                new Point3D
                {
                    X = (maxX + minX) / half,
                    Y = (maxY + minY) / half,
                    Z = maxZ
                },
                new Point3D
                {
                    X = (maxX + minX) / half,
                    Y = (maxY + minY) / half,
                    Z = maxZ + distance
                },

                //Left
                new Point3D
                {
                    X = (maxX + minX) / half,
                    Y = maxY,
                    Z = (maxZ + minZ) /half
                },
                new Point3D
                {
                    X = (maxX + minX) / half,
                    Y = maxY + distance,
                    Z = (maxZ + minZ) /half
                },

                //Down
                new Point3D
                {
                    X = (maxX + minX) / half,
                    Y = (maxY + minY) / half,
                    Z = minZ
                },
                new Point3D
                {
                    X = (maxX + minX) / half,
                    Y = (maxY + minY) / half,
                    Z = minZ - distance
                },

                //Face
                new Point3D
                {
                    X = maxX,
                    Y = (maxY + minY) / half,
                    Z = (minZ + maxZ) / half
                },
                new Point3D
                {
                    X = maxX + distance,
                    Y = (maxY + minY) / half,
                    Z = (minZ + maxZ) / half
                },

                //Right
                new Point3D
                {
                    X = (maxX + minX) / half,
                    Y = minY,
                    Z = (minZ + maxZ) / half
                },
                new Point3D
                {
                    X = (maxX + minX) / half,
                    Y = minY - distance,
                    Z = (minZ + maxZ) / half
                },

                //Back
                new Point3D
                {
                    X = minX,
                    Y = (minY + maxY) / half,
                    Z = (minZ + maxZ) / half
                },
                new Point3D
                {
                    X = minX - distance,
                    Y = (minY + maxY) / half,
                    Z = (minZ + maxZ) / half
                }
            };
        }
    }
}