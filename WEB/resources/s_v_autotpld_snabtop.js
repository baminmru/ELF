
 Ext.define('model_v_autotpld_snabtop',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'instanceid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name:'tpld_snabtop_cfio', type: 'string'}
            ,{name:'tpld_snabtop_caddress', type: 'string'}
            ,{name:'tpld_snabtop_cphone', type: 'string'}
            ,{name:'tpld_snabtop_cname', type: 'string'}
            ,{name:'tpld_snabtop_cregion', type: 'string'}
        ]
    });

    var store_v_autotpld_snabtop = Ext.create('Ext.data.Store', {
        model:'model_v_autotpld_snabtop',
        autoLoad: false,
        autoSync: false,
        remoteSort: true,
        remoteFilter:true,
        pageSize : 30,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_v_autotpld_snabtop/getRows',
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