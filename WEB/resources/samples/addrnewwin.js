

Ext.require([
    'Ext.tree.*',
    'Ext.data.*'
]);


function showAddrNewWin(caller) {

	var adrString;
	var addrwin;
	var region;
	var district;
	var town;
	var street;
	var street2;
	var adrtype;

	var region_txt="";
	var district_txt="";
	var town_txt="";
	var street_txt="";
	var street2_txt="";
	var adrtype_txt="";

  

    //if (!addrwin)
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
                    store:cmbstore_b2g_adrtype,
                    valueField:'b2g_adrtypeid',
                    displayField:'brief',
                    typeAhead:true,
                    queryMode:'local',
                    emptyText:'',
                    name:'adrtype',
                    itemId:'adrtype',
                    fieldLabel:'Тип адреса',
                    listeners:{
                        select:function (combo, selection) {
                            var post = selection[0];
                            if (post) {
								addrtype=post.get('b2g_adrtypeid');
								addrtype_txt=post.get('brief');
								
								if (addrtype_txt=='прямой; '){
                                    this.up('form').getForm().findField('house').enabledValue = true;
                                    this.up('form').getForm().findField('block').enabledValue = true;
                                    this.up('form').getForm().findField('house2').enabledValue = false;                                    
                                    this.up('form').getForm().findField('block2').enabledValue = false;
                                    this.up('form').getForm().findField('streetid2_grid').enabledValue = false;
								}else if(addrtype_txt=='между; '){
                                    this.up('form').getForm().findField('house').enabledValue = true;
                                    this.up('form').getForm().findField('block').enabledValue = true;
                                    this.up('form').getForm().findField('house2').enabledValue = true;
                                    this.up('form').getForm().findField('block2').enabledValue = true;
                                    this.up('form').getForm().findField('streetid2_grid').enabledValue = true;
								}else{
                                    this.up('form').getForm().findField('house').enabledValue = false;
                                    this.up('form').getForm().findField('block').enabledValue = false;
                                    this.up('form').getForm().findField('house2').enabledValue = false;
                                    this.up('form').getForm().findField('block2').enabledValue = false;
                                    this.up('form').getForm().findField('streetid2_grid').enabledValue = true;
                                }
                            }
                        }
                    }
                },
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
                                //else
                                 //   Ext.MessageBox.alert('Регион', combo + ' ' + combo.fieldLabel)
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
                    listeners:{
                        select:function (combo, selection) {
						    var post = selection[0];
                            if (post) {
                               

								district=post.get('b2g_addrid');
								district_txt=post.get('name');
                                var tw = combo.ownerCt.getComponent('ctown');
                                if (tw)
                                    tw.clearValue();
                                //else
                                //    Ext.MessageBox.alert('Нас. пункт:', combo + ' ' + combo.fieldLabel)
                                cmbstore_aw_town.load({params:{district:post.get('objectid')}});
								
								cmbstore_aw_street.load(
                                    {params:{node:post.get('treecode')}}
                                );
								cmbstore_aw_street2.load(
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
                    listeners:{
                        select:function (combo, selection) {
                            var post = selection[0];
                            if (post) {
                                town=post.get('b2g_addrid');
								town_txt=post.get('name');
								
                               cmbstore_aw_street.load(
                                    {params:{node:post.get('treecode')}}
                                );
								cmbstore_aw_street2.load(
                                    {params:{node:post.get('treecode')}}
                                );
                            }
                        }
                    }

                },
				 {
                    columnWidth:.5,
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
                    xtype:'combobox',
                    store:cmbstore_aw_street2,
                    valueField:'treecode',
                    displayField:'name',
                    typeAhead:true,
                    queryMode:'local',
                    emptyText:'',
                    name:'cstreet2',
                    itemId:'cstreet2',
                    fieldLabel:'Улица 2',
					disabled:true,
                    listeners:{
                        select:function (combo, selection) {
                            var post = selection[0];
                            if (post) {
                                street2=post.get('b2g_addrid');
								street2_txt=post.get('name');
							
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
                    allowBlank:true
                },
				{
                    columnWidth:.5,
                    xtype:'textfield',
                    fieldLabel:'Дом 2',
                    name:'house2',
                    itemId:'house2',
                    allowBlank:true,
					disabled:true
                },
                {
                    columnWidth:.5,
                    xtype:'textfield',
                    fieldLabel:'Корпус ',
                    name:'block',
                    itemId:'block',
                    allowBlank:true
                },
				  
                {
                    columnWidth:.5,
                    xtype:'textfield',
                    fieldLabel:'Корпус 2',
                    name:'block2',
                    itemId:'block2',
                    allowBlank:true,
					disabled:true
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
							
                                var house2 = this.up('form').getComponent('house2');
                                var block2 = this.up('form').getComponent('block2');
							
								var ff = caller.up('form');
								
								var ss="";
								
							
                                
								
								if (addrtype_txt=='прямой; ' ||  addrtype_txt=='' ){
									
									if (house.getValue()!=''){
										ss=street_txt+' д.'+house.getValue();
										if (block.getValue()!=''){
											ss=ss+' к.'+block.getValue();
										}	
									}else{
										ss=street_txt;
									}
									
								}else{
									if (house.getValue()!=''){
										ss=street_txt+' д.'+house.getValue();
										if (block.getValue()!=''){
										ss=ss+' к.'+block.getValue();
									}
									}else{
										ss=street_txt;
									}
									
									
									
									
									if (house2.getValue()!=''){
										ss=ss +"/" +street2_txt+' д.'+house.getValue();
										if (block2.getValue()!=''){
											ss=ss+' к.'+block.getValue();
										}
									}else{
										if(street2_txtx !=""){
											ss=ss +"/" +street2_txt;
										}
									}
									
								}
								
								if (ss==""){
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
											active.set('streetid2_grid',street2_txt);
										}catch( e){
											//alert('set error:' +e);
										}
										try{
											active.set('atype_grid',adrtype_txt); 
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
										active.set('streetid2',street2);
										}catch( e){
											//alert('set error:' +e);
										}
										try{
										active.set('atype',addrtype); 
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
										try{
										active.set('hosue2',house2.getValue()); 
										}catch( e){
											//alert('set error:' +e);
										}
										try{
										active.set('block2',block2.getValue()); 
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

        var naddrwin = Ext.widget('window', {
            title:'Выбор адреса',
            closeAction:'hide',
			constrainHeader :true,
            width:600,
            height:450,
            minHeight:450,
            layout:'fit',
            resizable:true,
            modal:true,
            items:form
        });
    }
    naddrwin.show();
	var cmbregion = naddrwin.items.getAt(0).getComponent('region');
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
    })
	
	var cmbatype = naddrwin.items.getAt(0).getComponent('adrtype');
    cmbstore_b2g_adrtype.on('load',function(store) {
      cmbatype.setValue('{CD959156-DAC9-4E7E-951C-2E7260CC1DE0}');
	  var record = cmbatype.findRecord(cmbatype.valueField , '{CD959156-DAC9-4E7E-951C-2E7260CC1DE0}')
	  addrtype=record.get('b2g_adrtypeid');
	  addrtype_txt=record.get('brief');
    })
	
	

    cmbstore_aw_region.load();
	cmbstore_b2g_adrtype.load();
}

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

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// панель адреса для первичной недвижимости
// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

var b2p_addr_panel = 
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
    id:'b2p_info-1',
    title:      'Адрес',
    defaultType:  'textfield',
    bodyPadding: 5,
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
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 5, 
                    y: 0, 
                    xtype:  'combobox',
                    editable: false,
                    store: cmbstore_b2g_adrtype,
                    valueField:     'brief',
                    displayField:   'brief',
                    typeAhead: true,
                    emptyText:      '',
                    name:   'atype_grid',
                    fieldLabel:  'Тип адреса',
                    listeners:{  
                        select: function ( combo, records, eOpts ) {
                            var p1 = this.up('form');
                            p1.activeRecord.set('atype', records[0].get('id'));       
                            
                            var post = records[0];

                            if (post) {
                                addrtype = post.get('b2g_adrtypeid');
                                addrtype_txt = post.get('brief');
                                
                                if (addrtype_txt=='прямой; '){
                                    this.up('form').getForm().findField('house').enabledValue = true;
                                    this.up('form').getForm().findField('block').enabledValue = true;
                                    this.up('form').getForm().findField('house2').enabledValue = false;                                    
                                    this.up('form').getForm().findField('block2').enabledValue = false;
                                    this.up('form').getForm().findField('streetid2_grid').enabledValue = false;
                                    this.up('form').getForm().findField('streetid2_grid').disable();
                                }else if(addrtype_txt=='между; '){
                                    this.up('form').getForm().findField('house').enabledValue = true;
                                    this.up('form').getForm().findField('block').enabledValue = true;
                                    this.up('form').getForm().findField('house2').enabledValue = true;
                                    this.up('form').getForm().findField('block2').enabledValue = true;
                                    this.up('form').getForm().findField('streetid2_grid').enabledValue = true;
                                    if(!this.up('form').getForm().findField('streetid1_grid').isDisabled())
                                        this.up('form').getForm().findField('streetid2_grid').enable();
                                }else{
                                    this.up('form').getForm().findField('house').enabledValue = false;
                                    this.up('form').getForm().findField('block').enabledValue = false;
                                    this.up('form').getForm().findField('house2').enabledValue = false;
                                    this.up('form').getForm().findField('block2').enabledValue = false;
                                    this.up('form').getForm().findField('streetid2_grid').enabledValue = true;
                                    if(!this.up('form').getForm().findField('streetid1_grid').isDisabled())
                                        this.up('form').getForm().findField('streetid2_grid').enable();
                                }
                                combo.up('form').getForm().findField('addressstring').updateSS();
                            }
                        }               
                    },
                    allowBlank: false
                },
                //адрес++++++++++++++++    
                {
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 5, 
                    y: 28, 
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
                            p1.activeRecord.set('streetid2', '');
                            combo.up('form').getForm().findField('districtid_grid').setValue('').disable();
                            combo.up('form').getForm().findField('cityid_grid').setValue('').disable();
                            combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();
                            combo.up('form').getForm().findField('streetid2_grid').setValue('').disable();

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
                    y: 28, 
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
                            p1.activeRecord.set('streetid2', '');
                            combo.up('form').getForm().findField('cityid_grid').setValue('').disable();
                            combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();  
                            combo.up('form').getForm().findField('streetid2_grid').setValue('').disable(); 

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
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 511, 
                    y: 28, 
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
                            p1.activeRecord.set('streetid2', '');
                            combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();   
                            combo.up('form').getForm().findField('streetid2_grid').setValue('').disable();   

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
                    y: 56, 
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
                                    if(combo.up('form').getForm().findField('streetid2_grid').enabledValue)
                                        combo.up('form').getForm().findField('streetid2_grid').enable();
                                }
                            }
                        });
                    }               
                },
                {
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 5, 
                    y: 56, 
                    xtype:  'combobox', 
                    disabled: true,
                    editable: true,
                    queryMode: 'local',
                    store: cmbstore_aw_street,
                    valueField:     'name',
                    displayField:   'name',
                    typeAhead: true,
                    emptyText:      '',
                    name:   'streetid2_grid',
                    autoSelect: true,
                    enabledValue: false,
                    // forceSelection: true,
                    fieldLabel:  'Улица 2',
                    listeners:{  
                        select: function ( combo, records, eOpts ) 
                        {
                            var p1 = this.up('form');
                            p1.activeRecord.set('streetid2', records[0].get('b2g_addrid'));
                            this.up('form').getForm().findField('addressstring').updateSS();
                        }  
                    },
                    allowBlank:true            
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
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 258, 
                    y: 56, 

                    xtype:  'textfield',
                    value:  '',
                    name:   'house',
                    fieldLabel:  'Дом',
                    enabledValue: true,
                    disabled: true,
                    allowBlank:true,
                    listeners: 
                    {
                        change: function()
                        {
                            this.up('form').getForm().findField('addressstring').updateSS();
                        }
                    }
                },    
                {
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 258, 
                    y: 56, 

                    xtype:  'textfield',
                    value:  '',
                    name:   'house2',
                    fieldLabel:  'Дом 2',
                    enabledValue: false,
                    disabled: true,
                    allowBlank:true,
                    listeners: 
                    {
                        change: function()
                        {
                            this.up('form').getForm().findField('addressstring').updateSS();
                        }
                    }
                },                       
                {
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 511, 
                    y: 56, 

                    xtype:  'textfield',
                    value:  '',
                    name:   'block',
                    fieldLabel:  'Корпус',
                    enabledValue: true,
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
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 511, 
                    y: 56, 

                    xtype:  'textfield',
                    value:  '',
                    name:   'block2',
                    fieldLabel:  'Корпус 2',
                    enabledValue: false,
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
                        var ss2 = "";
                        var atype_txt = this.up('form').getForm().findField('atype_grid').getValue();
                        var street_txt = this.up('form').getForm().findField('streetid1_grid').getValue();
                        var street2_txt = this.up('form').getForm().findField('streetid2_grid').getValue();
                        var town_txt = this.up('form').getForm().findField('cityid_grid').getValue();
                        var house = this.up('form').getForm().findField('house');
                        var block = this.up('form').getForm().findField('block');
                        var house2 = this.up('form').getForm().findField('house2');
                        var block2 = this.up('form').getForm().findField('block2');                        
                        var district_txt = this.up('form').getForm().findField('districtid_grid').getValue();
                        var region_txt = this.up('form').getForm().findField('regionid_grid').getValue();

                        if(this.up('form').getForm().findField('house').enabledValue)
                            this.up('form').getForm().findField('house').enable();
                        else
                            this.up('form').getForm().findField('house').disable();

                        if(this.up('form').getForm().findField('block').enabledValue)
                            this.up('form').getForm().findField('block').enable();
                        else
                            this.up('form').getForm().findField('block').disable();

                        if(this.up('form').getForm().findField('house2').enabledValue)
                            this.up('form').getForm().findField('house2').enable();
                        else
                            this.up('form').getForm().findField('house2').disable();

                        if(this.up('form').getForm().findField('block2').enabledValue)
                            this.up('form').getForm().findField('block2').enable();
                        else
                            this.up('form').getForm().findField('block2').disable();


                        if(street_txt == "") ss = ss + town_txt;
                        if(street2_txt == "") ss2 = ss2 + town_txt;
                            
                        if(street_txt != ""){
                            if(ss != "") ss = ss +", ";
                            ss = ss + street_txt;
                        }

                        if(street2_txt != ""){
                            if(ss2 != "") ss2 = ss2 +", ";
                            ss2 = ss2 + street2_txt;
                        }                        
                        
                        if (house.getValue()!=''){
                            ss = ss+' д.' + house.getValue();
                            if (block.getValue()!='') ss = ss+' к.'+block.getValue();
                        }

                        if (house2.getValue()!=''){
                            ss2 = ss2 + ' д.' + house2.getValue();
                            if (block2.getValue()!='') ss2 = ss2 + ' к.' + block2.getValue();
                        }

                        if(atype_txt == 'между; ') ss = 'между ' + ss + ' и ' + ss2; 
                        if(atype_txt == 'угол; ') ss = 'угол ' + street_txt + ' и ' + street2_txt;

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
} 

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// панель адреса для комплексов
// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

var cmbstore_bfrm_struct2_loaded=false;
var cmbstore_bfrm_struct2 = Ext.create('Ext.data.Store', {
    model:'cmbmodel_bfrm_struct',
    autoLoad: false,
    autoSync: false,
    remoteSort: false,
    remoteFilter: false,
    proxy: {
        type:   'ajax',
            url:   rootURL+'index.php/c_bfrm_struct2/getRows2',
        reader: {
            type:   'json'
            ,root:  'data'
            ,successProperty:  'success'
            ,messageProperty:  'msg'
        }
    },
   listeners: {
   'load': function(){combo_bfrm_struct_loaded =true;}
   }
});    

var b2b_addr_panel = 
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
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 5, 
                    y: 0, 
                    xtype:  'combobox',
                    editable: false,
                    store: cmbstore_b2g_adrtype,
                    valueField:     'brief',
                    displayField:   'brief',
                    typeAhead: true,
                    emptyText:      '',
                    name:   'atype_grid',
                    fieldLabel:  'Тип адреса',
                    listeners:{  
                        select: function ( combo, records, eOpts ) {
                            var p1 = this.up('form');
                            p1.activeRecord.set('atype', records[0].get('id'));       
                            
                            var post = records[0];

                            if (post) {
                                addrtype = post.get('b2g_adrtypeid');
                                addrtype_txt = post.get('brief');
                                
                                if (addrtype_txt=='прямой; '){
                                    this.up('form').getForm().findField('house').enabledValue = true;
                                    this.up('form').getForm().findField('block').enabledValue = true;
                                    this.up('form').getForm().findField('house2').enabledValue = false;                                    
                                    this.up('form').getForm().findField('block2').enabledValue = false;
                                    this.up('form').getForm().findField('streetid2_grid').enabledValue = false;
                                    this.up('form').getForm().findField('streetid2_grid').disable();
                                }else if(addrtype_txt=='между; '){
                                    this.up('form').getForm().findField('house').enabledValue = true;
                                    this.up('form').getForm().findField('block').enabledValue = true;
                                    this.up('form').getForm().findField('house2').enabledValue = true;
                                    this.up('form').getForm().findField('block2').enabledValue = true;
                                    this.up('form').getForm().findField('streetid2_grid').enabledValue = true;
                                    if(!this.up('form').getForm().findField('streetid1_grid').isDisabled())
                                        this.up('form').getForm().findField('streetid2_grid').enable();
                                }else{
                                    this.up('form').getForm().findField('house').enabledValue = false;
                                    this.up('form').getForm().findField('block').enabledValue = false;
                                    this.up('form').getForm().findField('house2').enabledValue = false;
                                    this.up('form').getForm().findField('block2').enabledValue = false;
                                    this.up('form').getForm().findField('streetid2_grid').enabledValue = true;
                                    if(!this.up('form').getForm().findField('streetid1_grid').isDisabled())
                                        this.up('form').getForm().findField('streetid2_grid').enable();
                                }
                                combo.up('form').getForm().findField('addressstring').updateSS();
                            }
                        }               
                    },
                    allowBlank: false
                },
                //адрес++++++++++++++++    
                {
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 5, 
                    y: 28, 
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
                            p1.activeRecord.set('streetid2', '');
                            combo.up('form').getForm().findField('districtid_grid').setValue('').disable();
                            combo.up('form').getForm().findField('cityid_grid').setValue('').disable();
                            combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();
                            combo.up('form').getForm().findField('streetid2_grid').setValue('').disable();

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
                    y: 28, 
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
                            p1.activeRecord.set('streetid2', '');
                            combo.up('form').getForm().findField('cityid_grid').setValue('').disable();
                            combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();  
                            combo.up('form').getForm().findField('streetid2_grid').setValue('').disable(); 

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
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 511, 
                    y: 28, 
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
                            p1.activeRecord.set('streetid2', '');
                            combo.up('form').getForm().findField('streetid1_grid').setValue('').disable();   
                            combo.up('form').getForm().findField('streetid2_grid').setValue('').disable();   

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
                    y: 56, 
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
                                    if(combo.up('form').getForm().findField('streetid2_grid').enabledValue)
                                        combo.up('form').getForm().findField('streetid2_grid').enable();
                                }
                            }
                        });
                    }               
                },
                {
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 5, 
                    y: 56, 
                    xtype:  'combobox',
                    disabled: true,
                    editable: true,
                    queryMode: 'local',
                    store: cmbstore_aw_street,
                    valueField:     'name',
                    displayField:   'name',
                    typeAhead: true,
                    emptyText:      '',
                    name:   'streetid2_grid',
                    autoSelect: true,
                    enabledValue: false,
                    // forceSelection: true,
                    fieldLabel:  'Улица 2',
                    listeners:{  
                        select: function ( combo, records, eOpts ) 
                        {
                            var p1 = this.up('form');
                            p1.activeRecord.set('streetid2', records[0].get('b2g_addrid'));
                            this.up('form').getForm().findField('addressstring').updateSS();
                        }  
                    },
                    allowBlank:true             
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
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 258, 
                    y: 56, 

                    xtype:  'textfield',
                    value:  '',
                    name:   'house',
                    fieldLabel:  'Дом',
                    enabledValue: true,
                    disabled: true,
                    allowBlank:true,
                    listeners: 
                    {
                        change: function()
                        {
                            this.up('form').getForm().findField('addressstring').updateSS();
                        }
                    }
                },    
                {
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 258, 
                    y: 56, 

                    xtype:  'textfield',
                    value:  '',
                    name:   'house2',
                    fieldLabel:  'Дом 2',
                    enabledValue: false,
                    disabled: true,
                    allowBlank:true,
                    listeners: 
                    {
                        change: function()
                        {
                            this.up('form').getForm().findField('addressstring').updateSS();
                        }
                    }
                },                       
                {
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 511, 
                    y: 56, 

                    xtype:  'textfield',
                    value:  '',
                    name:   'block',
                    fieldLabel:  'Корпус',
                    enabledValue: true,
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
                    minWidth: 249,
                    width: 249,
                    maxWidth: 249,
                    x: 511, 
                    y: 56, 

                    xtype:  'textfield',
                    value:  '',
                    name:   'block2',
                    fieldLabel:  'Корпус 2',
                    enabledValue: false,
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
                        var ss2 = "";
                        var atype_txt = this.up('form').getForm().findField('atype_grid').getValue();
                        var street_txt = this.up('form').getForm().findField('streetid1_grid').getValue();
                        var street2_txt = this.up('form').getForm().findField('streetid2_grid').getValue();
                        var town_txt = this.up('form').getForm().findField('cityid_grid').getValue();
                        var house = this.up('form').getForm().findField('house');
                        var block = this.up('form').getForm().findField('block');
                        var house2 = this.up('form').getForm().findField('house2');
                        var block2 = this.up('form').getForm().findField('block2');                        
                        var district_txt = this.up('form').getForm().findField('districtid_grid').getValue();
                        var region_txt = this.up('form').getForm().findField('regionid_grid').getValue();

                        if(this.up('form').getForm().findField('house').enabledValue)
                            this.up('form').getForm().findField('house').enable();
                        else
                            this.up('form').getForm().findField('house').disable();

                        if(this.up('form').getForm().findField('block').enabledValue)
                            this.up('form').getForm().findField('block').enable();
                        else
                            this.up('form').getForm().findField('block').disable();

                        if(this.up('form').getForm().findField('house2').enabledValue)
                            this.up('form').getForm().findField('house2').enable();
                        else
                            this.up('form').getForm().findField('house2').disable();

                        if(this.up('form').getForm().findField('block2').enabledValue)
                            this.up('form').getForm().findField('block2').enable();
                        else
                            this.up('form').getForm().findField('block2').disable();


                        if(street_txt == "") ss = ss + town_txt;
                        if(street2_txt == "") ss2 = ss2 + town_txt;
                            
                        if(street_txt != ""){
                            if(ss != "") ss = ss +", ";
                            ss = ss + street_txt;
                        }

                        if(street2_txt != ""){
                            if(ss2 != "") ss2 = ss2 +", ";
                            ss2 = ss2 + street2_txt;
                        }                        
                        
                        if (house.getValue()!=''){
                            ss = ss+' д.' + house.getValue();
                            if (block.getValue()!='') ss = ss+' к.'+block.getValue();
                        }

                        if (house2.getValue()!=''){
                            ss2 = ss2 + ' д.' + house2.getValue();
                            if (block2.getValue()!='') ss2 = ss2 + ' к.' + block2.getValue();
                        }

                        if(atype_txt == 'между; ') ss = 'между ' + ss + ' и ' + ss2; 
                        if(atype_txt == 'угол; ') ss = 'угол ' + street_txt + ' и ' + street2_txt;

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
} 