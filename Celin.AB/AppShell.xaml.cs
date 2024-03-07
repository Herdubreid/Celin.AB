using Celin.AB.Views;

namespace Celin.AB
{
    public partial class AppShell : Shell
    {
        public void GoToView(W01012B.Row row)
        {
            var view = Items.FirstOrDefault(v => v.Route == row.z_AN8_19.ToString());

            if (view == null)
            {
                var fo = new FlyoutItem
                {
                    Title = row.z_ALPH_20,
                };

                fo.Items.Add(new ShellContent
                {
                    Route = row.z_AN8_19.ToString(),
                    ContentTemplate = new DataTemplate(()
                        => new ViewPage(row))
                });

                Items.Add(fo);
            }

            GoToAsync(row.z_AN8_19.ToString());
        }
        private void About_Clicked(object sender, EventArgs e)
        {
            GoToAsync("about");
        }
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("about", typeof(AboutPage));
        }
    }
}
