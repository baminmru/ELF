﻿
<?php
class  M_tpsrv_modems extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tpsrv_modemsid) as tpsrv_modemsid, B2G(tpsrv_modemsid) as id,B2G(instanceid) as instanceid, TPSRV_MODEMS_BRIEF_F(tpsrv_modemsid , NULL) as  brief,  DATE_FORMAT(useduntil,\'%Y-%m-%d %H:%i:%s\') as  useduntil,isused, case isused  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as isused_grid,isusable, case isusable  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as isusable_grid,portnum', 'PartName' => 'tpsrv_modems', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tpsrv_modemsid'])) {
	        $data['tpsrv_modemsid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpsrv_modems', 'RowID' => $data['tpsrv_modemsid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tpsrv_modems', 'RowID' => $data['tpsrv_modemsid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tpsrv_modemsid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpsrv_modems', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpsrv_modemsid) as tpsrv_modemsid, B2G(tpsrv_modemsid) as id,B2G(instanceid) as instanceid, TPSRV_MODEMS_BRIEF_F(tpsrv_modemsid , NULL) as  brief,  DATE_FORMAT(useduntil,\'%Y-%m-%d %H:%i:%s\') as  useduntil,isused, case isused  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as isused_grid,isusable, case isusable  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as isusable_grid,portnum', 'ViewName' => 'tpsrv_modems'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpsrv_modemsid) as tpsrv_modemsid, B2G(tpsrv_modemsid) as id,B2G(instanceid) as instanceid, TPSRV_MODEMS_BRIEF_F(tpsrv_modemsid , NULL) as  brief,  DATE_FORMAT(useduntil,\'%Y-%m-%d %H:%i:%s\') as  useduntil,isused, case isused  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as isused_grid,isusable, case isusable  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as isusable_grid,portnum', 'ViewName' => 'tpsrv_modems', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpsrv_modemsid) as tpsrv_modemsid, B2G(tpsrv_modemsid) as id,B2G(instanceid) as instanceid, TPSRV_MODEMS_BRIEF_F(tpsrv_modemsid , NULL) as  brief,  DATE_FORMAT(useduntil,\'%Y-%m-%d %H:%i:%s\') as  useduntil,isused, case isused  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as isused_grid,isusable, case isusable  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as isusable_grid,portnum', 'ViewName' => 'tpsrv_modems', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tpsrv_modems', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>