﻿using Xamarin.Forms;

namespace AppMascotas.Validations
{
    //validacion de datos  de entrada maxima logitud
    class MaxLengthValidatorBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int), typeof(MaxLengthValidatorBehavior), 0);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.Unfocused += Unfocused;
            base.OnAttachedTo(entry);
        }

        // Devuelve una cadena de máximo una longitud permitida
        private void Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;

            entry.Text = entry.Text.Substring(0, MaxLength);

        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.Unfocused -= Unfocused;
            base.OnDetachingFrom(entry);
        }
    }
}
