namespace Maui_SearchStylingIssue {
  public class MySearchHandler : SearchHandler {
    public MySearchHandler() {
      BackgroundColor = Colors.White;
    }

    List<string> _strings = new List<string> { "One", "Two", "Three", "Four", "Five" };


    protected override void OnQueryChanged( string oldValue, string newValue ) {
      base.OnQueryChanged( oldValue, newValue );
      if ( newValue != null && newValue.Length > 0 ) {
        ItemsSource = _strings.Where( x => x.ToLower().Contains( newValue.ToLower() ) );
      }
      else {
        ItemsSource = _strings;
      }
    }
    protected override async void OnItemSelected( object item ) {
      base.OnItemSelected( item );
    }
  }


  public partial class MainPage : ContentPage {
    int count = 0;

    public MainPage() {
      InitializeComponent();
    }

    private void OnCounterClicked( object sender, EventArgs e ) {
      count++;

      if ( count == 1 )
        CounterBtn.Text = $"Clicked {count} time";
      else
        CounterBtn.Text = $"Clicked {count} times";

      SemanticScreenReader.Announce( CounterBtn.Text );
    }
  }

}
