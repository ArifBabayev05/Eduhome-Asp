//Settings: IEntity
//Prop key
//Prop valure

//dbset

//Services	=> Interface ISettingService
//Repository => SettingRepository 

//implement

//Private readonly Appdb _con => ctor

//Public async Task<Dicti> Get(string key)
//{
//    //if (id is Null)
//    var data = (await _context.Settings.todictionaryasync(n => n.key, n => n.value)[key];
//    return data;

//}

//public async Task<Dictioary<string, string>> GetALl()
//{

//    var data = _context.settings.TodictionaryAsync(n => n => n.key, n => n.value)
//        rturn data.Values;

//}


//migration SettingTable
//    Icindekiler: HeaderLogo, FooterLogo,facebookLogo, pintLogo, TwitterLogo




    
//shared: _Layout
//    using Busimess.Repository
//    @inject SettingRepositoy _settings;


//logo sekli yerine    @_settings.Get("HeaderIcon");
//link yerlierine @_settings.Get("facebookLink");



//new folder Components
//create new class HeaderViewCOmponent
//new class HeaderViewCOmponent : ViewComponent


//_layout
//    @await Component.InvokeAsync("Header");
//;

//puclic async Task<IViewComponentResult> InvokdeAsync()

//{

//    private readonly SettingRepository _setting;
//    public HeaderViewCOmponent(SettingRep setting)
//    {
//        _setting = setting
//    }

//    public async Task<IViewComponentResult> InvokeAsync()
//    {
//        List<string> datas = new List<string>();
//        datas.add(_setting.Get("HeaderIcon;
//            return view()
//    }
//    retrn view();
//}

//Create New Folder "Components" => "Header" => "Default.cshtml";

//Layout Headerini bura yapisdir

//@model list<string>

//    @model[0];











