
Ext.require([
'Ext.form.*'
]);
  bprcfg_new= null;
function bprcfg_Panel_new(objectID, RootPanel, selection){ 


    var store_iu_rcfg_def = Ext.create('Ext.data.Store', {
        model:'model_iu_rcfg_def',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_iu_rcfg_def/getRows',
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
          DefineForms_iu_rcfg_def_new();
     var   int_iu_rcfg_def_new     =      DefineInterface_iu_rcfg_def_new('int_iu_rcfg_def',store_iu_rcfg_def, selection);
     bprcfg_new= Ext.create('Ext.form.Panel', {
      id: 'bprcfg',
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
        	    int_iu_rcfg_def_new.doSave( me.onCommit);
        		},
        		onButtonCancel: function()
        		{
        		},
        canClose: function(){
        	return int_iu_rcfg_def_new.canClose();
        },
        items: [{
            xtype:'tabpanel',
            itemId:'tabs_bprcfg',
            activeTab: 0,
            layout: 'fit',
            tabPosition:'top',
            border:0,
            items:[   // tabs
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Роль',
            layout:'fit',
            itemId:'tab_iu_rcfg_def',
            items:[ // panel on tab 
int_iu_rcfg_def_new
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       bprcfg_new.closable= true;
       bprcfg_new.title= 'Настройка роли';
       bprcfg_new.frame= true;
    }else{
       bprcfg_new.closable= false;
       bprcfg_new.title= '';
       bprcfg_new.frame= false;
    }
   store_iu_rcfg_def.on('load', function() {
        if(store_iu_rcfg_def.count()==0){
            store_iu_rcfg_def.insert(0, new model_iu_rcfg_def());
        }
        record= store_iu_rcfg_def.getAt(0);
        record['instanceid']=objectID;
   int_iu_rcfg_def_new.setActiveRecord(record,objectID);	
   });
       store_iu_rcfg_def.load( {params:{ instanceid:objectID} }  );
    return bprcfg_new;
}