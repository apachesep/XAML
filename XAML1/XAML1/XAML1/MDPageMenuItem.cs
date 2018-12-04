using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XAML1
{

    public class MDPageMenuItem
    {
        public MDPageMenuItem()
        {
            TargetType = typeof(MDPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public Color TitleColor { get; set; } = Color.FromHex("#00AEFF");

        public Type TargetType { get; set; }
    }
}