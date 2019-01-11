
<?php
class  M_tplt_connect extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tplt_connectid) as tplt_connectid, B2G(tplt_connectid) as id,B2G(instanceid) as instanceid, TPLT_CONNECT_BRIEF_F(tplt_connectid , NULL) as  brief,cparity, case cparity  when 0 then \'None\' when 1 then \'Even\' when 2 then \'Odd\' when 3 then \'Mark\' when 4 then \'Space\' else \'\'  end   as cparity_grid,connectionenabled, case connectionenabled  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as connectionenabled_grid,ipaddr,comportnum,cdatabit,portnum,cspeed,callerid,cphone,username,ctowncode,netaddr,password,atcommand,B2G(ConnectType) connecttype, TPLD_CONNECTTYPE_BRIEF_F(connecttype, NULL) as connecttype_grid,flowcontrol,B2G(TheServer) theserver, TPSRV_INFO_BRIEF_F(theserver, NULL) as theserver_grid,connectlimit,cstopbits', 'PartName' => 'tplt_connect', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tplt_connectid'])) {
	        $data['tplt_connectid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplt_connect', 'RowID' => $data['tplt_connectid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tplt_connect', 'RowID' => $data['tplt_connectid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tplt_connectid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplt_connect', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_connectid) as tplt_connectid, B2G(tplt_connectid) as id,B2G(instanceid) as instanceid, TPLT_CONNECT_BRIEF_F(tplt_connectid , NULL) as  brief,cparity, case cparity  when 0 then \'None\' when 1 then \'Even\' when 2 then \'Odd\' when 3 then \'Mark\' when 4 then \'Space\' else \'\'  end   as cparity_grid,connectionenabled, case connectionenabled  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as connectionenabled_grid,ipaddr,comportnum,cdatabit,portnum,cspeed,callerid,cphone,username,ctowncode,netaddr,password,atcommand,B2G(ConnectType) connecttype, TPLD_CONNECTTYPE_BRIEF_F(connecttype, NULL) as connecttype_grid,flowcontrol,B2G(TheServer) theserver, TPSRV_INFO_BRIEF_F(theserver, NULL) as theserver_grid,connectlimit,cstopbits', 'ViewName' => 'tplt_connect'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_connectid) as tplt_connectid, B2G(tplt_connectid) as id,B2G(instanceid) as instanceid, TPLT_CONNECT_BRIEF_F(tplt_connectid , NULL) as  brief,cparity, case cparity  when 0 then \'None\' when 1 then \'Even\' when 2 then \'Odd\' when 3 then \'Mark\' when 4 then \'Space\' else \'\'  end   as cparity_grid,connectionenabled, case connectionenabled  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as connectionenabled_grid,ipaddr,comportnum,cdatabit,portnum,cspeed,callerid,cphone,username,ctowncode,netaddr,password,atcommand,B2G(ConnectType) connecttype, TPLD_CONNECTTYPE_BRIEF_F(connecttype, NULL) as connecttype_grid,flowcontrol,B2G(TheServer) theserver, TPSRV_INFO_BRIEF_F(theserver, NULL) as theserver_grid,connectlimit,cstopbits', 'ViewName' => 'tplt_connect', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_connectid) as tplt_connectid, B2G(tplt_connectid) as id,B2G(instanceid) as instanceid, TPLT_CONNECT_BRIEF_F(tplt_connectid , NULL) as  brief,cparity, case cparity  when 0 then \'None\' when 1 then \'Even\' when 2 then \'Odd\' when 3 then \'Mark\' when 4 then \'Space\' else \'\'  end   as cparity_grid,connectionenabled, case connectionenabled  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as connectionenabled_grid,ipaddr,comportnum,cdatabit,portnum,cspeed,callerid,cphone,username,ctowncode,netaddr,password,atcommand,B2G(ConnectType) connecttype, TPLD_CONNECTTYPE_BRIEF_F(connecttype, NULL) as connecttype_grid,flowcontrol,B2G(TheServer) theserver, TPSRV_INFO_BRIEF_F(theserver, NULL) as theserver_grid,connectlimit,cstopbits', 'ViewName' => 'tplt_connect', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tplt_connect', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>