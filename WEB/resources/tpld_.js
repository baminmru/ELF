
Ext.require([
'Ext.form.*'
]);
  tpld_= null;
function TPLD_Panel_(objectID, RootPanel, selection){ 


    var store_tpld_snabtop = Ext.create('Ext.data.Store', {
        model:'model_tpld_snabtop',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_snabtop/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tpld_param = Ext.create('Ext.data.Store', {
        model:'model_tpld_param',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_param/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tpld_snab = Ext.create('Ext.data.Store', {
        model:'model_tpld_snab',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_snab/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tpld_f = Ext.create('Ext.data.Store', {
        model:'model_tpld_f',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_f/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tpld_connecttype = Ext.create('Ext.data.Store', {
        model:'model_tpld_connecttype',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_connecttype/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tpld_devclass = Ext.create('Ext.data.Store', {
        model:'model_tpld_devclass',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_devclass/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tpld_devtype = Ext.create('Ext.data.Store', {
        model:'model_tpld_devtype',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_devtype/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tpld_grp = Ext.create('Ext.data.Store', {
        model:'model_tpld_grp',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_grp/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tpld_paramtype = Ext.create('Ext.data.Store', {
        model:'model_tpld_paramtype',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_paramtype/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });
          DefineForms_tpld_snabtop_();
          DefineForms_tpld_param_();
          DefineForms_tpld_snab_();
          DefineForms_tpld_f_();
          DefineForms_tpld_connecttype_();
          DefineForms_tpld_devclass_();
          DefineForms_tpld_devtype_();
          DefineForms_tpld_grp_();
          DefineForms_tpld_paramtype_();
     var   int_tpld_snabtop_     =      DefineInterface_tpld_snabtop_('int_tpld_snabtop',store_tpld_snabtop);
     var   int_tpld_param_     =      DefineInterface_tpld_param_('int_tpld_param',store_tpld_param);
     var   int_tpld_snab_     =      DefineInterface_tpld_snab_('int_tpld_snab',store_tpld_snab);
     var   int_tpld_f_     =      DefineInterface_tpld_f_('int_tpld_f',store_tpld_f);
     var   int_tpld_connecttype_     =      DefineInterface_tpld_connecttype_('int_tpld_connecttype',store_tpld_connecttype);
     var   int_tpld_devclass_     =      DefineInterface_tpld_devclass_('int_tpld_devclass',store_tpld_devclass);
     var   int_tpld_devtype_     =      DefineInterface_tpld_devtype_('int_tpld_devtype',store_tpld_devtype);
     var   int_tpld_grp_     =      DefineInterface_tpld_grp_('int_tpld_grp',store_tpld_grp);
     var   int_tpld_paramtype_     =      DefineInterface_tpld_paramtype_('int_tpld_paramtype',store_tpld_paramtype);
     tpld_= Ext.create('Ext.form.Panel', {
      id: 'tpld',
      layout:'fit',
      fieldDefaults: {
          labelAlign:             'top',
          msgTarget:              'side'
        },
        defaults: {
        anchor:'100%'
        },

        instanceid:objectID,
                onCommit: function(){
        		},
        		onButtonOk: function()
        		{
        			var me = this;
        		},
        		onButtonCancel: function()
        		{
        		},
        canClose: function(){
        	return true;
        },
        items: [{
            xtype:'tabpanel',
            itemId:'tabs_tpld',
            activeTab: 0,
            layout: 'fit',
            tabPosition:'top',
            border:0,
            items:[   // tabs
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Поставщик',
            layout:'fit',
            itemId:'tab_tpld_snabtop',
            items:[ // panel on tab 
int_tpld_snabtop_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Параметры',
            layout:'fit',
            itemId:'tab_tpld_param',
            items:[ // panel on tab 
int_tpld_param_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Снабжающая организация',
            layout:'fit',
            itemId:'tab_tpld_snab',
            items:[ // panel on tab 
int_tpld_snab_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Филиал организации',
            layout:'fit',
            itemId:'tab_tpld_f',
            items:[ // panel on tab 
int_tpld_f_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Тип подключения',
            layout:'fit',
            itemId:'tab_tpld_connecttype',
            items:[ // panel on tab 
int_tpld_connecttype_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Класс устройства',
            layout:'fit',
            itemId:'tab_tpld_devclass',
            items:[ // panel on tab 
int_tpld_devclass_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Тип устройства',
            layout:'fit',
            itemId:'tab_tpld_devtype',
            items:[ // panel on tab 
int_tpld_devtype_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Группа',
            layout:'fit',
            itemId:'tab_tpld_grp',
            items:[ // panel on tab 
int_tpld_grp_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Тип архива',
            layout:'fit',
            itemId:'tab_tpld_paramtype',
            items:[ // panel on tab 
int_tpld_paramtype_
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       tpld_.closable= true;
       tpld_.title= 'Справочник';
       tpld_.frame= true;
    }else{
       tpld_.closable= false;
       tpld_.title= '';
       tpld_.frame= false;
    }
   int_tpld_snabtop_.instanceid=objectID;	
       store_tpld_snabtop.load(  {params:{ instanceid:objectID} } );
   int_tpld_param_.instanceid=objectID;	
       store_tpld_param.load(  {params:{ instanceid:objectID} } );
   int_tpld_snab_.instanceid=objectID;	
       store_tpld_snab.load(  {params:{ instanceid:objectID} } );
   int_tpld_f_.instanceid=objectID;	
       store_tpld_f.load(  {params:{ instanceid:objectID} } );
   int_tpld_connecttype_.instanceid=objectID;	
       store_tpld_connecttype.load(  {params:{ instanceid:objectID} } );
   int_tpld_devclass_.instanceid=objectID;	
       store_tpld_devclass.load(  {params:{ instanceid:objectID} } );
   int_tpld_devtype_.instanceid=objectID;	
       store_tpld_devtype.load(  {params:{ instanceid:objectID} } );
   int_tpld_grp_.instanceid=objectID;	
       store_tpld_grp.load(  {params:{ instanceid:objectID} } );
   int_tpld_paramtype_.instanceid=objectID;	
       store_tpld_paramtype.load(  {params:{ instanceid:objectID} } );
    return tpld_;
}