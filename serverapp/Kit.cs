using System;

namespace backend
{
    public class Kit
    {
        int typeId;
        double price;
        string size, name, colorsAvailable, optionsAvailable, imageName;
        public Kit(int typeId, string name, string size, double price, string colorsAvailable, string optionsAvailable, string imageName)
        {
            this.typeId = typeId;
            this.name = name;
            this.size = size;
            this.price = price;
            this.colorsAvailable = colorsAvailable;
            this.optionsAvailable = optionsAvailable;
            this.imageName = imageName;
        }

        public override string ToString()
        {
            return typeId.ToString() + '/' + name + '/' + size + '/' + price + '/' + colorsAvailable + '/' + optionsAvailable + '/' + imageName;
        }
    }
}
