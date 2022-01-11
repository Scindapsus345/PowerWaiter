using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using PowerWaiters.Droid;
using PowerWaiters.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientLabel), typeof(GradientLabelRenderer))]
namespace PowerWaiters.Droid
{
    public class GradientLabelRenderer : LabelRenderer
    {
        public GradientLabelRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            SetColors();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            SetColors();
        }
        private void SetColors()
        {
            var c1 = (Element as GradientLabel).TextColor1.ToAndroid();
            var c2 = (Element as GradientLabel).TextColor2.ToAndroid();
            Shader myShader = new LinearGradient(
                0, 0, 0, Control.MeasuredHeight,
                c1, c2,
                Shader.TileMode.Clamp);
            Control.Paint.SetShader(myShader);
            Control.Invalidate();
        }
    }
}