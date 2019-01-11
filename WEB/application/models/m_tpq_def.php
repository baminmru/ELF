
<?php
class  M_tpq_def extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tpq_defid) as tpq_defid, B2G(tpq_defid) as id,B2G(instanceid) as instanceid, TPQ_DEF_BRIEF_F(tpq_defid , NULL) as  brief,isurgent, case isurgent  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as isurgent_grid,repeattimes,repeatinterval,  DATE_FORMAT(querytime,\'%Y-%m-%d %H:%i:%s\') as  querytime,B2G(TheDevice) thedevice, TPLT_BDEVICES_BRIEF_F(thedevice, NULL) as thedevice_grid,  DATE_FORMAT(archtime,\'%Y-%m-%d %H:%i:%s\') as  archtime,B2G(TheSessionID) thesessionid, the_Session_BRIEF_F(thesessionid, NULL) as thesessionid_grid,B2G(ArchType) archtype, TPLD_PARAMTYPE_BRIEF_F(archtype, NULL) as archtype_grid', 'PartName' => 'tpq_def', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tpq_defid'])) {
	        $data['tpq_defid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpq_def', 'RowID' => $data['tpq_defid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tpq_def', 'RowID' => $data['tpq_defid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tpq_defid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpq_def', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpq_defid) as tpq_defid, B2G(tpq_defid) as id,B2G(instanceid) as instanceid, TPQ_DEF_BRIEF_F(tpq_defid , NULL) as  brief,isurgent, case isurgent  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as isurgent_grid,repeattimes,repeatinterval,  DATE_FORMAT(querytime,\'%Y-%m-%d %H:%i:%s\') as  querytime,B2G(TheDevice) thedevice, TPLT_BDEVICES_BRIEF_F(thedevice, NULL) as thedevice_grid,  DATE_FORMAT(archtime,\'%Y-%m-%d %H:%i:%s\') as  archtime,B2G(TheSessionID) thesessionid, the_Session_BRIEF_F(thesessionid, NULL) as thesessionid_grid,B2G(ArchType) archtype, TPLD_PARAMTYPE_BRIEF_F(archtype, NULL) as archtype_grid', 'ViewName' => 'tpq_def'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpq_defid) as tpq_defid, B2G(tpq_defid) as id,B2G(instanceid) as instanceid, TPQ_DEF_BRIEF_F(tpq_defid , NULL) as  brief,isurgent, case isurgent  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as isurgent_grid,repeattimes,repeatinterval,  DATE_FORMAT(querytime,\'%Y-%m-%d %H:%i:%s\') as  querytime,B2G(TheDevice) thedevice, TPLT_BDEVICES_BRIEF_F(thedevice, NULL) as thedevice_grid,  DATE_FORMAT(archtime,\'%Y-%m-%d %H:%i:%s\') as  archtime,B2G(TheSessionID) thesessionid, the_Session_BRIEF_F(thesessionid, NULL) as thesessionid_grid,B2G(ArchType) archtype, TPLD_PARAMTYPE_BRIEF_F(archtype, NULL) as archtype_grid', 'ViewName' => 'tpq_def', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpq_defid) as tpq_defid, B2G(tpq_defid) as id,B2G(instanceid) as instanceid, TPQ_DEF_BRIEF_F(tpq_defid , NULL) as  brief,isurgent, case isurgent  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as isurgent_grid,repeattimes,repeatinterval,  DATE_FORMAT(querytime,\'%Y-%m-%d %H:%i:%s\') as  querytime,B2G(TheDevice) thedevice, TPLT_BDEVICES_BRIEF_F(thedevice, NULL) as thedevice_grid,  DATE_FORMAT(archtime,\'%Y-%m-%d %H:%i:%s\') as  archtime,B2G(TheSessionID) thesessionid, the_Session_BRIEF_F(thesessionid, NULL) as thesessionid_grid,B2G(ArchType) archtype, TPLD_PARAMTYPE_BRIEF_F(archtype, NULL) as archtype_grid', 'ViewName' => 'tpq_def', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tpq_def', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>