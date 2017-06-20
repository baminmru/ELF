


Ext.require([
    'Ext.tree.*',
    'Ext.data.*'
]);


function showAddrWin(caller) {

	var adrString;
	var addrwin;
	var region;
	var district;
	var town;
	var street;

	var region_txt="";
	var district_txt="";
	var town_txt="";
	var street_txt="";

	{
        var form = Ext.widget('form', {
            layout:{
                type:'column'
            },
            border:false,
            bodyPadding:10,

            fieldDefaults:{
                labelAlign:'top',
                labelWidth:100,
                labelStyle:'font-weight:bold'
            },
            defaults:{
                margins:'0 0 10 0'
            },

            items:[
                {
                    columnWidth:1,
                    xtype:'combobox',
                    store:cmbstore_aw_region,
                    valueField:'treecode',
                    displayField:'name',
                    typeAhead:true,
                    queryMode:'local',
                    emptyText:'',
                    name:'region',
                    itemId:'region',
                    fieldLabel:'Регион',
					listeners:{
                        select:function (combo, selection) {
                            var post = selection[0];
                            if (post) {
                              
								region=post.get('b2g_addrid');
								region_txt=post.get('name');
                                var dist = combo.ownerCt.getComponent('district');
                                if (dist)
                                    dist.clearValue();
                               
                                cmbstore_aw_district.load({params:{region:post.get('objectid')}});



                            }
                        }
                    }
                },
                {
                    columnWidth:1,
                    xtype:'combobox',
                    store:cmbstore_aw_district,
                    valueField:'treecode',
                    displayField:'name',
                    typeAhead:true,
                    queryMode:'local',
                    emptyText:'',
                    name:'district',
                    itemId:'district',
                    fieldLabel:'Район',
					//plugins: new Ext.ux.form.field.ClearButton({animateClearButton: false}),
                    listeners:{
                        select:function (combo, selection) {
						    var post = selection[0];
                            if (post) {
                               

								district=post.get('b2g_addrid');
								district_txt=post.get('name');
                                var tw = combo.ownerCt.getComponent('ctown');
                                if (tw)
                                    tw.clearValue();
                                cmbstore_aw_town.load({params:{district:post.get('objectid')}});
								
								cmbstore_aw_street.load(
                                    {params:{node:post.get('treecode')}}
                                );

                            }
                        }
                    }

                },
                {
                    columnWidth:1,
                    xtype:'combobox',
                    store:cmbstore_aw_town,
                    valueField:'treecode',
                    displayField:'name',
                    typeAhead:true,
                    queryMode:'local',
                    emptyText:'',
                    name:'ctown',
                    itemId:'ctown',
                    fieldLabel:'Нас. пункт',
					plugins: ['clearbutton'],
                    listeners:{
                        select:function (combo, selection) {
                            var post = selection[0];
                            if (post) {
                                town=post.get('b2g_addrid');
								town_txt=post.get('name');
								
                               cmbstore_aw_street.load(
                                    {params:{node:post.get('treecode')}}
                                );
							
                            }
                        }
                    }

                },
				 {
                    columnWidth:1,
                    xtype:'combobox',
                    store:cmbstore_aw_street,
                    valueField:'treecode',
                    displayField:'name',
                    typeAhead:true,
                    queryMode:'local',
                    emptyText:'',
                    name:'cstreet',
                    itemId:'cstreet',
                    fieldLabel:'Улица',
					plugins: ['clearbutton'],
                    listeners:{
                        select:function (combo, selection) {
                            var post = selection[0];
                            if (post) {
                                street=post.get('b2g_addrid');
								street_txt=post.get('name');
							
                            }
                        }
                    }

                },

                {
                    columnWidth:.5,
                    xtype:'textfield',
                    fieldLabel:'Дом',
                    name:'house',
                    itemId:'house',
					plugins: ['clearbutton'],
                    allowBlank:true
                },
                {
                    columnWidth:.5,
                    xtype:'textfield',
                    fieldLabel:'Корпус ',
                    name:'block',
                    itemId:'block',
					plugins: ['clearbutton'],
                    allowBlank:true
                }
            ],

            buttons:[
               
                {
                    text:'Задать',
					iconCls:'icon-accept',
                    handler:function () {
                        if (this.up('form').getForm().isValid()) {
							var house = this.up('form').getComponent('house');
                            var block = this.up('form').getComponent('block');
                            var tree = this.up('form').getComponent('tree');
                         
							
							var ff = caller.up('form');
							
							var ss = "";
							if(street_txt=="")
								ss=ss+town_txt ;
								
							if(street_txt!=""){
								if(ss!="")
									ss=ss +", ";
								ss=ss+street_txt;
							}
							
							if (house.getValue()!=''){
								ss=ss+' д.'+house.getValue();
								if (block.getValue()!=''){
									ss=ss+' к.'+block.getValue();
								}
							}
							
							if ( district_txt=="" || region_txt==""){
									Ext.MessageBox.show({
									title:  'Информация',
									 msg:    'Не заполнены необходимые поля',
									buttons: Ext.MessageBox.OK,
									 icon:   Ext.MessageBox.INFO
									});
									return;
							}
								
							if (ss=="" ){
									Ext.MessageBox.show({
									title:  'Информация',
									 msg:    'Не заполнены необходимые поля',
									buttons: Ext.MessageBox.OK,
									 icon:   Ext.MessageBox.INFO
									});
									return;
							}
							caller.setValue(ss);

                                
							if (ff){
								var form =ff.getForm()
								var active=ff.activeRecord;
								if(active){
									
									form.updateRecord(active);
									try{
										active.set('regionid_grid',region_txt); 
										}catch( e){
										//alert('set error:' +e);
									}
									try{
										active.set('districtid_grid',district_txt); 	
										}catch( e){
										//alert('set error:' +e);
									}
									try{
										active.set('cityid_grid',town_txt); 	
										}catch( e){
										//alert('set error:' +e);
									}
									try{
										active.set('streetid1_grid',street_txt);
										}catch( e){
										//alert('set error:' +e);
									}
									try{
									}catch( e){
										//alert('set error:' +e);
									}
									try{
									active.set('regionid',region); 
									}catch( e){
										//alert('set error:' +e);
									}
									try{
									active.set('districtid',district); 	
									}catch( e){
										//alert('set error:' +e);
									}
									try{
									active.set('cityid',town); 	
									}catch( e){
										//alert('set error:' +e);
									}
									try{
									active.set('streetid1',street); 
									}catch( e){
										//alert('set error:' +e);
									}
									try{
									active.set('house',house.getValue()); 
									}catch( e){
										//alert('set error:' +e);
									}
									try{
									active.set('block',block.getValue()); 
									}catch( e){
										//alert('set error:' +e);
									}
									
								
									//alert (active);
									form.loadRecord(active);
								}
						
							}
                            
                            this.up('form').getForm().reset();
                            this.up('window').hide();
                        }
                    }
                },
				 {
                    text:'Отмена',
					iconCls:'icon-cancel',
                    handler:function () {
                        this.up('form').getForm().reset();
                        this.up('window').hide();
                    }
                }
            ]
        });

        addrwin = Ext.widget('window', {
            title:'Выбор адреса',
            closeAction:'hide',
            width:600,
            height:370,
            minHeight:350,
			constrainHeader :true,
            layout:'fit',
            resizable:true,
            modal:true,
            items:form
        });
    }
    addrwin.show();
	var cmbregion = addrwin.items.getAt(0).getComponent('region');
    cmbstore_aw_region.on('load',function(store) {
    cmbregion.setValue('000001');
	var record = cmbregion.findRecord(cmbregion.valueField , '000001')
		if (record) {
			region=record.get('b2g_addrid');
			region_txt=record.get('name');
			var dist = cmbregion.ownerCt.getComponent('district');
			if (dist)
				dist.clearValue();
			cmbstore_aw_district.load({params:{region:record.get('objectid')}});
		}
    });
    cmbstore_aw_region.load();
}




var b2s_addr_panel = 
{ 
    xtype:'panel', 
    closable:false,
    collapsible:true,
    titleCollapse : true,
    x: 0, 
    layout:'absolute', 
    bodyPadding: 5,
    id:'b2s_info-addr',
    title:      'Адрес',
    defaultType:  'textfield',
    items: 
    [
//адрес++++++++++++++++    
        {
            minWidth: 249,
            width: 249,
            maxWidth: 249,
            x: 5, 
            y: 0, 
            xtype:  'combobox',
            editable: false,
            store: cmbstore_aw_region,
            valueField:     'name',
            displayField:   'name',
            typeAhead: true,
            emptyText:      '',
            name:   'regionid_grid',
            allowBlank: false,
            fieldLabel:  'Регион',
            listeners:{  
                expand: function ( field, eOpts )
                {
                    this.setValue('');
                },
                select: function ( combo, records, eOpts ) {
                    var p1 = this.up('form');
                    p1.activeRecord.set('regionid', records[0].get('b2g_addrid'));
                    //обнуление и отключение всех последующих полей
                    p1.activeRecord.set('districtid', '');
                    p1.activeRecord.set('cityid', '');
                    p1.activeRecord.set('streetid1', '');
                    combo.up('form').getForm().findField('districtid_grid').setValue('').disable();
                    combo.up('form').getForm().findField('cityid_grid').setValue('').disable();
                    combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();

                    var post = records[0];
                    if (post) {
                        var combo = this;

                        combo.up('form').getForm().findField('districtid_grid').clearValue();

                        //Загрузка районов для данного региона
                        combo.up('form').getForm().findField('districtid_grid').loadStore(
                            {region: post.get('objectid')}, //параметры
                            post.get('objectid'), //регион
                            post.get('treecode') //код для улиц
                            );
                        combo.up('form').getForm().findField('addressstring').allowUpdateSS = true;
                        combo.up('form').getForm().findField('addressstring').updateSS();
                    }                        
                }  
            }
        }
        ,
        {
            minWidth: 249,
            width: 249,
            maxWidth: 249,
            x: 258, 
            y: 0, 
            disabled: true,
            xtype:  'combobox',
            editable: false,
            store: cmbstore_aw_district,
            valueField: 'name',
            displayField: 'name',
            queryMode: 'local',
            typeAhead: true,
            emptyText:      '',
            allowBlank: false,
            name:   'districtid_grid',
            fieldLabel:  'Район',
            listeners:{  
                select: function ( combo, records, eOpts ) {
                    var p1 = this.up('form');
                    p1.activeRecord.set('districtid', records[0].get('b2g_addrid'));
                    //обнуление и отключение всех последующих полей
                    p1.activeRecord.set('cityid', '');
                    p1.activeRecord.set('streetid1', '');
                    combo.up('form').getForm().findField('cityid_grid').setValue('').disable();
                    combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();  

                    var post = records[0];
                    if (post) {
                        combo.up('form').getForm().findField('cityid_grid').loadStore({district:post.get('objectid')}, post.get('treecode'));
                        this.up('form').getForm().findField('addressstring').updateSS();
                    }                          
                }  
            },
            loadStore: function(params, regionid, nodeid)
            {
                var combo = this;
                cmbstore_aw_district.load({
                    params: params,
                    callback: function(records, operation, success) {
                        if(!success || !records || records.length == 0 || !records[0].get('objectid')) 
                        {
                            //Загрузка городов региона
                            combo.up('form').getForm().findField('cityid_grid').loadStore({district: regionid}, nodeid);
                        }else
                        {
                            //В случае успеха активируем поле
                            combo.up('form').getForm().findField('districtid_grid').enable();
                        }
                    }
                });
            }

        }
        ,
        {
            minWidth: 249,
            width: 249,
            maxWidth: 249,
            x: 511, 
            y: 0, 
            disabled: true,
            xtype:  'combobox',
            editable: false,
            store: cmbstore_aw_town,
            valueField: 'name',
            displayField:  'name',
            typeAhead: true,
            emptyText:      '',
            queryMode: 'local',
            name:   'cityid_grid',
            fieldLabel:  'Населенный пункт',
            listeners:{  
                select: function ( combo, records, eOpts ) {
                    var p1 = this.up('form');
                    p1.activeRecord.set('cityid', records[0].get('b2g_addrid'));
                    //обнуление и отключение всех последующих полей
                    p1.activeRecord.set('streetid1', '');
                    combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();   

                    var post = records[0];
                    if (post) {                        
                        combo.up('form').getForm().findField('streetid1_grid').loadStore({node: post.get('treecode')});
                        this.up('form').getForm().findField('addressstring').updateSS();
                    }                            
                }  
            },
            allowBlank:true,
            loadStore: function(params, nodeid)
            {
                var combo = this;
                cmbstore_aw_town.load({
                    params: params,
                    callback: function(records, operation, success) {
                        if(!success || !records || records.length == 0 || !records[0].get('objectid')) 
                        {
                            //Загрузка улиц региона
                            combo.up('form').getForm().findField('streetid1_grid').loadStore({node: nodeid});
                        }else
                        {
                            //В случае успеха активируем поле
                            combo.up('form').getForm().findField('cityid_grid').enable();
                        }
                    }
                });
                combo.up('form').getForm().findField('streetid1_grid').loadStore({node: nodeid});
            }           

        }
        ,
        {
            minWidth: 249,
            width: 249,
            maxWidth: 249,
            x: 5, 
            y: 28, 
            xtype:  'combobox',
            disabled: true,
            editable: true,
            queryMode: 'local',
            store: cmbstore_aw_street,
            valueField:     'name',
            displayField:   'name',
            typeAhead: true,
            emptyText:      '',
            name:   'streetid1_grid',
            autoSelect: true,
            // forceSelection: true,
            fieldLabel:  'Улица',
            listeners:{  
                select: function ( combo, records, eOpts ) 
                {
                    var p1 = this.up('form');
                    p1.activeRecord.set('streetid1', records[0].get('b2g_addrid'));
                    this.up('form').getForm().findField('addressstring').updateSS();
                }  
            },
            allowBlank:true,
            loadStore: function(params)
            {
                var combo = this;
                cmbstore_aw_street.load({
                    params: params,
                    callback: function(records, operation, success) {
                        if(!success || !records || records.length == 0 || !records[0].get('objectid')) 
                        {
                            //ничего не происходит
                        }else
                        {
                            //В случае успеха активируем поле
                            combo.up('form').getForm().findField('streetid1_grid').enable();
                        }
                    }
                });
            }               
        }
        ,
        {
            minWidth: 249,
            width: 249,
            maxWidth: 249,
            x: 258, 
            y: 28, 

            xtype:  'textfield',
            value:  '',
            name:   'house',
            fieldLabel:  'Дом',
            disabled: true,
            allowBlank:true,
            listeners: 
            {
                change: function()
                {
                    this.up('form').getForm().findField('addressstring').updateSS();
                }
            }
        }
        ,
        {
            minWidth: 249,
            width: 249,
            maxWidth: 249,
            x: 511, 
            y: 28, 

            xtype:  'textfield',
            value:  '',
            name:   'block',
            fieldLabel:  'Корпус',
            disabled: true,
            allowBlank:true,
            listeners: 
            {
                change: function()
                {
                    this.up('form').getForm().findField('addressstring').updateSS();
                }
            }            
        }
        ,
        {
            minWidth: 249,
            width: 249,
            maxWidth: 249,
            x: 5, 
            y: 56, 
            beforeLabelTextTpl:'<img src="/resources/icons/lock.png" style="height:16px;width:16px;border:0;"/>&nbsp;&nbsp;',

            xtype:  'textfield',
            value:  '',
            name:   'flat',
            fieldLabel:  'Квартира',
            allowBlank:true
        }
        ,       
        {
            minWidth: 249,
            width: 249,
            maxWidth: 249,
            x: 258, 
            y: 56, 
            xtype:  'textfield',
            readOnly: true,
            name:   'addressstring',
            fieldLabel:  'Адрес',
            labelClsExtra:'x-item-mandatory',
            allowUpdateSS: false,
            updateSS: function()
            {
                if(!this.allowUpdateSS) return;
                var ss = "";
                var street_txt = this.up('form').getForm().findField('streetid1_grid').getValue();
                var town_txt = this.up('form').getForm().findField('cityid_grid').getValue();
                var house = this.up('form').getForm().findField('house');
                var block = this.up('form').getForm().findField('block');
                var district_txt = this.up('form').getForm().findField('districtid_grid').getValue();
                var region_txt = this.up('form').getForm().findField('regionid_grid').getValue();

                this.up('form').getForm().findField('house').enable();
                this.up('form').getForm().findField('block').enable();

                if(street_txt == "")
                    ss = ss+town_txt;
                    
                if(street_txt != ""){
                    if(ss != "")
                        ss = ss +", ";
                    ss = ss + street_txt;
                }
                
                if (house.getValue()!=''){
                    ss=ss+' д.' + house.getValue();
                    if (block.getValue()!=''){
                        ss = ss+' к.'+block.getValue();
                    }
                }
                
                this.setValue(ss);

                this.clearInvalid();
                console.log(district_txt);
                console.log(region_txt);

                if (region_txt == "" || !region_txt || ( (district_txt == "" || !district_txt) && (town_txt == "" || !town_txt) && (street_txt == "" || !street_txt) ) ){
                    this.markInvalid('Не выбран регион, район, город или улица');
                }
                    
                if (ss == "" ){
                    this.markInvalid('Не заполнены необходимые поля');
                }
            }

        }


//адрес ----------------
    ]
    , 
    width: 769,
    height: 114 
} // group

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// панель адреса для зарубежки
// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

var b2fr_addr_panel = 
{ 
    xtype:'panel', 
    closable:false,
    collapsible:true,
    titleCollapse : true,
    layout: 
    {
        type: 'vbox',
        align: 'stretch'
    },
    bodyPadding: 5,
    id:'b2b_info-1',
    title:      'Адрес',
    defaultType:  'textfield',
    items: 
    [
        {
            xtype: 'fieldcontainer',
            defaultType:  'textfield',
            layout: 'hbox',
            fieldDefaults: 
            {   
                labelAlign:  'right'
            },
            defaults: 
            {
                flex: 1
            },
            items: [
                {
                    columnWidth:1,
                    xtype:'combobox',
                    store:cmbstore_aw_country,
                    valueField:'name',
                    displayField:'name',
                    typeAhead:true,
                    queryMode:'local',
                    emptyText:'',
                    name:'countryid_grid',
                    itemId:'country',
                    fieldLabel:'Страна',
					allowBlank:false,
                    listeners:{
						focus: function()   {  this.store.load();  },
                        select:function (combo, selection) {
                            var p1 = this.up('form');
                            p1.activeRecord.set('countryid', selection[0].get('b2g_addrid'));
                            
                            //обнуление и отключение всех последующих полей
                            p1.activeRecord.set('regionid', '');
                            p1.activeRecord.set('districtid', '');
                            p1.activeRecord.set('cityid', '');
                            p1.activeRecord.set('streetid1', '');
                            combo.up('form').getForm().findField('regionid_grid').setValue('').disable();
                            combo.up('form').getForm().findField('districtid_grid').setValue('').disable();
                            combo.up('form').getForm().findField('cityid_grid').setValue('').disable();
                            combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();

                            var post = selection[0];
                            if (post) {
                                
                                combo.up('form').getForm().findField('regionid_grid').loadStore({country: post.get('objectid')}, post.get('objectid'));

                                combo.up('form').getForm().findField('addressstring').allowUpdateSS = true;
                                combo.up('form').getForm().findField('addressstring').updateSS();
                                /*
                                country=post.get('b2g_addrid');
                                country_txt=post.get('name');
                                var dist = combo.ownerCt.getComponent('region');
                                if (dist)
                                    dist.clearValue();
                                //else
                                 //   Ext.MessageBox.alert('Страна', combo + ' ' + combo.fieldLabel)
                                cmbstore_aw_region2.load({params:{country:post.get('objectid')}});

                                var tw = combo.ownerCt.getComponent('ctown');
                                if (tw)
                                    tw.clearValue();
                               
                                cmbstore_aw_town.load({params:{district:post.get('objectid')}});
                                */
                            } 
                        }
                    }
                },    
                //адрес++++++++++++++++    
                {

                    xtype:  'combobox',
                    editable: false,
                    disabled: true,
                    store: cmbstore_aw_region2,
                    valueField:     'name',
                    displayField:   'name',
                    typeAhead: true,
                    emptyText:      '',
                    name:   'regionid_grid',
                    allowBlank: false,
                    fieldLabel:  'Регион',
                    listeners:{  
                        expand: function ( field, eOpts )
                        {
                        //    this.setValue('');
                        },
                        select: function ( combo, records, eOpts ) {
                            var p1 = this.up('form');
                            p1.activeRecord.set('regionid', records[0].get('b2g_addrid'));
                            //обнуление и отключение всех последующих полей
                            p1.activeRecord.set('districtid', '');
                            p1.activeRecord.set('cityid', '');
                            p1.activeRecord.set('streetid1', '');
                            combo.up('form').getForm().findField('districtid_grid').setValue('').disable();
                            combo.up('form').getForm().findField('cityid_grid').setValue('').disable();
                            combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();

                            var post = records[0];
                            if (post) {
                                var combo = this;

                                combo.up('form').getForm().findField('districtid_grid').clearValue();

                                //Загрузка районов для данного региона
                                combo.up('form').getForm().findField('districtid_grid').loadStore(
                                    {region: post.get('objectid')}, //параметры
                                    post.get('objectid'), //регион
                                    post.get('treecode') //код для улиц
                                    );
                                combo.up('form').getForm().findField('addressstring').allowUpdateSS = true;
                                combo.up('form').getForm().findField('addressstring').updateSS();
                            }                        
                        }  
                    },
                    loadStore: function(params, countryid)
                    {
                        var combo = this;
                        cmbstore_aw_region2.load({
                            params: params,
                            callback: function(records, operation, success) {
                                if(!success || !records || records.length == 0 || !records[0].get('objectid')) 
                                {
                                    //Загрузка городов страны
                                    combo.up('form').getForm().findField('districtid_grid').loadStore(
                                        {region: countryid}, //параметры
                                         countryid, //регион
                                         0 //код для улиц
                                    );
                                }else
                                {
                                    //В случае успеха активируем поле
                                    combo.up('form').getForm().findField('regionid_grid').enable();
                                }
                            }
                        });
                    }            
                }
                ,
                {
                    disabled: true,
                    xtype:  'combobox',
                    editable: false,
                    store: cmbstore_aw_district,
                    valueField: 'name',
                    displayField: 'name',
                    queryMode: 'local',
                    typeAhead: true,
                    emptyText:      '',
                    allowBlank: false,
                    name:   'districtid_grid',
                    fieldLabel:  'Район',
                    listeners:{  
                        select: function ( combo, records, eOpts ) {
                            var p1 = this.up('form');
                            p1.activeRecord.set('districtid', records[0].get('b2g_addrid'));
                            //обнуление и отключение всех последующих полей
                            p1.activeRecord.set('cityid', '');
                            p1.activeRecord.set('streetid1', '');
                            combo.up('form').getForm().findField('cityid_grid').setValue('').disable();
                            combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();  

                            var post = records[0];
                            if (post) {
                                combo.up('form').getForm().findField('cityid_grid').loadStore({district:post.get('objectid')}, post.get('treecode'));
                                this.up('form').getForm().findField('addressstring').updateSS();
                            }                          
                        }  
                    },
                    loadStore: function(params, regionid, nodeid)
                    {
                        var combo = this;
                        cmbstore_aw_district.load({
                            params: params,
                            callback: function(records, operation, success) {
                                if(!success || !records || records.length == 0 || !records[0].get('objectid')) 
                                {
                                    //Загрузка городов региона
                                    combo.up('form').getForm().findField('cityid_grid').loadStore({district: regionid}, nodeid);
                                }else
                                {
                                    //В случае успеха активируем поле
                                    combo.up('form').getForm().findField('districtid_grid').enable();
                                }
                            }
                        });
                    }

                }
            ]
        },
        {
            xtype: 'fieldcontainer',
            defaultType:  'textfield',
            layout: 'hbox',
            fieldDefaults: 
            {   
                labelAlign:  'right'
            },
            defaults: 
            {
                flex: 1
            },
            items: [
                {
                    disabled: true,
                    xtype:  'combobox',
                    editable: false,
                    store: cmbstore_aw_town,
                    valueField: 'name',
                    displayField:  'name',
                    typeAhead: true,
                    emptyText:      '',
                    queryMode: 'local',
                    name:   'cityid_grid',
                    fieldLabel:  'Населенный пункт',
                    listeners:{  
                        select: function ( combo, records, eOpts ) {
                            var p1 = this.up('form');
                            p1.activeRecord.set('cityid', records[0].get('b2g_addrid'));
                            //обнуление и отключение всех последующих полей
                            p1.activeRecord.set('streetid1', '');
                            combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();   

                            var post = records[0];
                            if (post) {                        
                                combo.up('form').getForm().findField('streetid1_grid').loadStore({node: post.get('treecode')});
                                this.up('form').getForm().findField('addressstring').updateSS();
                            }                            
                        }  
                    },
                    allowBlank:true,
                    loadStore: function(params, nodeid)
                    {
                        var combo = this;
                        cmbstore_aw_town.load({
                            params: params,
                            callback: function(records, operation, success) {
                                if(!success || !records || records.length == 0 || !records[0].get('objectid')) 
                                {
                                    //Загрузка улиц региона
                                    combo.up('form').getForm().findField('streetid1_grid').loadStore({node: nodeid});
                                }else
                                {
                                    //В случае успеха активируем поле
                                    combo.up('form').getForm().findField('cityid_grid').enable();
                                }
                            }
                        });
                        combo.up('form').getForm().findField('streetid1_grid').loadStore({node: nodeid});
                    }           

                }
                ,
                {

                    xtype:  'combobox',
                    disabled: true,
                    editable: true,
                    queryMode: 'local',
                    store: cmbstore_aw_street,
                    valueField:     'name',
                    displayField:   'name',
                    typeAhead: true,
                    emptyText:      '',
                    name:   'streetid1_grid',
                    autoSelect: true,
                    // forceSelection: true,
                    fieldLabel:  'Улица',
                    listeners:{  
                        select: function ( combo, records, eOpts ) 
                        {
                            var p1 = this.up('form');
                            p1.activeRecord.set('streetid1', records[0].get('b2g_addrid'));
                            this.up('form').getForm().findField('addressstring').updateSS();
                        }  
                    },
                    allowBlank:true,
                    loadStore: function(params)
                    {
                        var combo = this;
                        cmbstore_aw_street.load({
                            params: params,
                            callback: function(records, operation, success) {
                                if(!success || !records || records.length == 0 || !records[0].get('objectid')) 
                                {
                                    //ничего не происходит
                                }else
                                {
                                    //В случае успеха активируем поле
                                    combo.up('form').getForm().findField('streetid1_grid').enable();
                                }
                            }
                        });
                    }               
                }
                ,
                {

                    xtype:  'textfield',
                    value:  '',
                    name:   'house',
                    fieldLabel:  'Дом',
                    disabled: true,
                    allowBlank:true,
                    listeners: 
                    {
                        change: function()
                        {
                            this.up('form').getForm().findField('addressstring').updateSS();
                        }
                    }
                }
            ]
        }
        ,
        {
            xtype: 'fieldcontainer',
            defaultType:  'textfield',
            layout: 'hbox',
            fieldDefaults: 
            {   
                labelAlign:  'right'
            },
            defaults: 
            {
                flex: 1
            },
            items: [
        
                {
                    xtype:  'textfield',
                    value:  '',
                    name:   'block',
                    fieldLabel:  'Корпус',
                    disabled: true,
                    allowBlank:true,
                    listeners: 
                    {
                        change: function()
                        {
                            this.up('form').getForm().findField('addressstring').updateSS();
                        }
                    }            
                }
                ,
                {
                    beforeLabelTextTpl:'<img src="/resources/icons/lock.png" style="height:16px;width:16px;border:0;"/>&nbsp;&nbsp;',

                    xtype:  'textfield',
                    value:  '',
                    name:   'flat',
                    fieldLabel:  'Квартира',
                    allowBlank:true
                }
                ,       
                {
                    xtype:  'textfield',
                    readOnly: false,
                    name:   'addressstring',
                    fieldLabel:  'Адрес',
                    labelClsExtra:'x-item-mandatory',
                    allowUpdateSS: false,
                    updateSS: function()
                    {
                        if(!this.allowUpdateSS) return;
                        var ss = "";
                        var street_txt = this.up('form').getForm().findField('streetid1_grid').getValue();
                        var town_txt = this.up('form').getForm().findField('cityid_grid').getValue();
                        var house = this.up('form').getForm().findField('house');
                        var block = this.up('form').getForm().findField('block');
                        var district_txt = this.up('form').getForm().findField('districtid_grid').getValue();
                        var region_txt = this.up('form').getForm().findField('regionid_grid').getValue();

                        this.up('form').getForm().findField('house').enable();
                        this.up('form').getForm().findField('block').enable();

                        if(street_txt == "")
                            ss = ss+town_txt;
                            
                        if(street_txt != ""){
                            if(ss != "")
                                ss = ss +", ";
                            ss = ss + street_txt;
                        }
                        
                        if (house.getValue()!=''){
                            ss=ss+' д.' + house.getValue();
                            if (block.getValue()!=''){
                                ss = ss+' к.'+block.getValue();
                            }
                        }
                        
                        this.setValue(ss);

                        this.clearInvalid();
                        console.log(district_txt);
                        console.log(region_txt);

                        if (region_txt == "" || !region_txt || ( (district_txt == "" || !district_txt) && (town_txt == "" || !town_txt) && (street_txt == "" || !street_txt) ) ){
                            this.markInvalid('Не выбран регион, район, город или улица');
                        }
                            
                        if (ss == "" ){
                            this.markInvalid('Не заполнены необходимые поля');
                        }
                    }

                }
            ]
        }

//адрес ----------------
    ]
    , 
    width: 769
} // group