
 Ext.define('model_v_autotplt_bdevices',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'instanceid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name:'tplt_bdevices_theschema', type: 'string'}
            ,{name:'tplt_bdevices_nplock', type: 'string'}
            ,{name:'tplt_bdevices_shab', type: 'string'}
            ,{name:'tplt_bdevices_theserver', type: 'string'}
            ,{name:'tplt_bdevices_thenode', type: 'string'}
            ,{name:'tplt_bdevices_devtype', type: 'string'}
            ,{name:'tplt_bdevices_name', type: 'string'}
            ,{name:'tplt_bdevices_devgrp', type: 'string'}
            ,{name:'tplt_bdevices_addr', type: 'string'}
            ,{name:'tplt_bdevices_thephone', type: 'string'}
            ,{name:'tplt_bdevices_connected', type: 'string'}
        ]
    });

    var store_v_autotplt_bdevices = Ext.create('Ext.data.Store', {
        model:'model_v_autotplt_bdevices',
        autoLoad: false,
        autoSync: false,
        remoteSort: true,
        remoteFilter:true,
        pageSize : 30,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_v_autotplt_bdevices/getRows',
            reader: {
                type:   'json'
                ,root:  'rows'
                ,totalProperty: 'total'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            },
            listeners: {
                exception: function(proxy, response, operation){
                    Ext.MessageBox.show({
                        title: 'REMOTE EXCEPTION',
                        msg:    operation.getError(),
                        icon : Ext.MessageBox.ERROR,
                        buttons : Ext.Msg.OK
                    });
                }
            }
        }
    });