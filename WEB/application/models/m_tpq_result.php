
<?php
class  M_tpq_result extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tpq_resultid) as tpq_resultid, B2G(tpq_resultid) as id,B2G(instanceid) as instanceid, TPQ_result_BRIEF_F(tpq_resultid , NULL) as  brief,B2G(TotalArch) totalarch, TPLC_T_BRIEF_F(totalarch, NULL) as totalarch_grid,textresult,B2G(DayArch) dayarch, TPLC_D_BRIEF_F(dayarch, NULL) as dayarch_grid,logmessage,  DATE_FORMAT(endtime,\'%Y-%m-%d %H:%i:%s\') as  endtime,B2G(HourArch) hourarch, TPLC_H_BRIEF_F(hourarch, NULL) as hourarch_grid,B2G(MomentArch) momentarch, TPLC_M_BRIEF_F(momentarch, NULL) as momentarch_grid,  DATE_FORMAT(starttime,\'%Y-%m-%d %H:%i:%s\') as  starttime,iserror, case iserror  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as iserror_grid', 'PartName' => 'tpq_result', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tpq_resultid'])) {
	        $data['tpq_resultid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpq_result', 'RowID' => $data['tpq_resultid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tpq_result', 'RowID' => $data['tpq_resultid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tpq_resultid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpq_result', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpq_resultid) as tpq_resultid, B2G(tpq_resultid) as id,B2G(instanceid) as instanceid, TPQ_result_BRIEF_F(tpq_resultid , NULL) as  brief,B2G(TotalArch) totalarch, TPLC_T_BRIEF_F(totalarch, NULL) as totalarch_grid,textresult,B2G(DayArch) dayarch, TPLC_D_BRIEF_F(dayarch, NULL) as dayarch_grid,logmessage,  DATE_FORMAT(endtime,\'%Y-%m-%d %H:%i:%s\') as  endtime,B2G(HourArch) hourarch, TPLC_H_BRIEF_F(hourarch, NULL) as hourarch_grid,B2G(MomentArch) momentarch, TPLC_M_BRIEF_F(momentarch, NULL) as momentarch_grid,  DATE_FORMAT(starttime,\'%Y-%m-%d %H:%i:%s\') as  starttime,iserror, case iserror  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as iserror_grid', 'ViewName' => 'tpq_result'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpq_resultid) as tpq_resultid, B2G(tpq_resultid) as id,B2G(instanceid) as instanceid, TPQ_result_BRIEF_F(tpq_resultid , NULL) as  brief,B2G(TotalArch) totalarch, TPLC_T_BRIEF_F(totalarch, NULL) as totalarch_grid,textresult,B2G(DayArch) dayarch, TPLC_D_BRIEF_F(dayarch, NULL) as dayarch_grid,logmessage,  DATE_FORMAT(endtime,\'%Y-%m-%d %H:%i:%s\') as  endtime,B2G(HourArch) hourarch, TPLC_H_BRIEF_F(hourarch, NULL) as hourarch_grid,B2G(MomentArch) momentarch, TPLC_M_BRIEF_F(momentarch, NULL) as momentarch_grid,  DATE_FORMAT(starttime,\'%Y-%m-%d %H:%i:%s\') as  starttime,iserror, case iserror  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as iserror_grid', 'ViewName' => 'tpq_result', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpq_resultid) as tpq_resultid, B2G(tpq_resultid) as id,B2G(instanceid) as instanceid, TPQ_result_BRIEF_F(tpq_resultid , NULL) as  brief,B2G(TotalArch) totalarch, TPLC_T_BRIEF_F(totalarch, NULL) as totalarch_grid,textresult,B2G(DayArch) dayarch, TPLC_D_BRIEF_F(dayarch, NULL) as dayarch_grid,logmessage,  DATE_FORMAT(endtime,\'%Y-%m-%d %H:%i:%s\') as  endtime,B2G(HourArch) hourarch, TPLC_H_BRIEF_F(hourarch, NULL) as hourarch_grid,B2G(MomentArch) momentarch, TPLC_M_BRIEF_F(momentarch, NULL) as momentarch_grid,  DATE_FORMAT(starttime,\'%Y-%m-%d %H:%i:%s\') as  starttime,iserror, case iserror  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as iserror_grid', 'ViewName' => 'tpq_result', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tpq_result', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>