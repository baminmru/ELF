
<?php
class  M_tplt_bdevices extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tplt_bdevicesid) as tplt_bdevicesid, B2G(tplt_bdevicesid) as id,B2G(instanceid) as instanceid, TPLT_BDEVICES_BRIEF_F(tplt_bdevicesid , NULL) as  brief,  DATE_FORMAT(nplock,\'%Y-%m-%d %H:%i:%s\') as  nplock,B2G(DEVType) devtype, TPLD_DEVTYPE_BRIEF_F(devtype, NULL) as devtype_grid,B2G(DevGrp) devgrp, TPLD_GRP_BRIEF_F(devgrp, NULL) as devgrp_grid,addr,B2G(Shab) shab, TPLD_SNAB_BRIEF_F(shab, NULL) as shab_grid,name,B2G(TheNode) thenode, TPN_DEF_BRIEF_F(thenode, NULL) as thenode_grid,thephone,B2G(THESCHEMA) theschema, TPLS_INFO_BRIEF_F(theschema, NULL) as theschema_grid,B2G(TheServer) theserver, TPSRV_INFO_BRIEF_F(theserver, NULL) as theserver_grid,connected, case connected  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as connected_grid', 'PartName' => 'tplt_bdevices', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tplt_bdevicesid'])) {
	        $data['tplt_bdevicesid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplt_bdevices', 'RowID' => $data['tplt_bdevicesid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tplt_bdevices', 'RowID' => $data['tplt_bdevicesid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tplt_bdevicesid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplt_bdevices', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_bdevicesid) as tplt_bdevicesid, B2G(tplt_bdevicesid) as id,B2G(instanceid) as instanceid, TPLT_BDEVICES_BRIEF_F(tplt_bdevicesid , NULL) as  brief,  DATE_FORMAT(nplock,\'%Y-%m-%d %H:%i:%s\') as  nplock,B2G(DEVType) devtype, TPLD_DEVTYPE_BRIEF_F(devtype, NULL) as devtype_grid,B2G(DevGrp) devgrp, TPLD_GRP_BRIEF_F(devgrp, NULL) as devgrp_grid,addr,B2G(Shab) shab, TPLD_SNAB_BRIEF_F(shab, NULL) as shab_grid,name,B2G(TheNode) thenode, TPN_DEF_BRIEF_F(thenode, NULL) as thenode_grid,thephone,B2G(THESCHEMA) theschema, TPLS_INFO_BRIEF_F(theschema, NULL) as theschema_grid,B2G(TheServer) theserver, TPSRV_INFO_BRIEF_F(theserver, NULL) as theserver_grid,connected, case connected  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as connected_grid', 'ViewName' => 'tplt_bdevices'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_bdevicesid) as tplt_bdevicesid, B2G(tplt_bdevicesid) as id,B2G(instanceid) as instanceid, TPLT_BDEVICES_BRIEF_F(tplt_bdevicesid , NULL) as  brief,  DATE_FORMAT(nplock,\'%Y-%m-%d %H:%i:%s\') as  nplock,B2G(DEVType) devtype, TPLD_DEVTYPE_BRIEF_F(devtype, NULL) as devtype_grid,B2G(DevGrp) devgrp, TPLD_GRP_BRIEF_F(devgrp, NULL) as devgrp_grid,addr,B2G(Shab) shab, TPLD_SNAB_BRIEF_F(shab, NULL) as shab_grid,name,B2G(TheNode) thenode, TPN_DEF_BRIEF_F(thenode, NULL) as thenode_grid,thephone,B2G(THESCHEMA) theschema, TPLS_INFO_BRIEF_F(theschema, NULL) as theschema_grid,B2G(TheServer) theserver, TPSRV_INFO_BRIEF_F(theserver, NULL) as theserver_grid,connected, case connected  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as connected_grid', 'ViewName' => 'tplt_bdevices', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_bdevicesid) as tplt_bdevicesid, B2G(tplt_bdevicesid) as id,B2G(instanceid) as instanceid, TPLT_BDEVICES_BRIEF_F(tplt_bdevicesid , NULL) as  brief,  DATE_FORMAT(nplock,\'%Y-%m-%d %H:%i:%s\') as  nplock,B2G(DEVType) devtype, TPLD_DEVTYPE_BRIEF_F(devtype, NULL) as devtype_grid,B2G(DevGrp) devgrp, TPLD_GRP_BRIEF_F(devgrp, NULL) as devgrp_grid,addr,B2G(Shab) shab, TPLD_SNAB_BRIEF_F(shab, NULL) as shab_grid,name,B2G(TheNode) thenode, TPN_DEF_BRIEF_F(thenode, NULL) as thenode_grid,thephone,B2G(THESCHEMA) theschema, TPLS_INFO_BRIEF_F(theschema, NULL) as theschema_grid,B2G(TheServer) theserver, TPSRV_INFO_BRIEF_F(theserver, NULL) as theserver_grid,connected, case connected  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as connected_grid', 'ViewName' => 'tplt_bdevices', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tplt_bdevices', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>