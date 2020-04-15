using Desktop.Presentation.Common.Interfaces;

using System.Collections.Generic;

namespace Desktop.Presentation.Dialogs.SelectFile
{
    public class SelectFileDialog : IDialog<SelectFileResponse>
    {
        public IList<FilterInfo> Filter { get; set; }
    }

    public class SelectFileResponse
    {
        public string FileName { get; set; }
    }

    public class FilterInfo
    {
        public FilterInfo( string filter )
        {
            if ( string.IsNullOrEmpty( filter ) )
            {
                throw new System.ArgumentNullException( "message", nameof( filter ) );
            }

            Filter = filter;
        }

        public FilterInfo( string filter, string description ) : this( filter )
        {
            if ( string.IsNullOrEmpty( description ) )
            {
                throw new System.ArgumentNullException( "message", nameof( description ) );
            }

            Description = description;
        }

        public string Filter { get; }
        public string Description { get; }
    }
}
