<?php
	 class C_tpq_result extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPQ_result.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPQ_result.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpq_resultid' =>  $this->input->get_post('tpq_resultid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'textresult' =>   $this->input->get_post('textresult', TRUE)
                ,'momentarch' =>   $this->input->get_post('momentarch', TRUE)
                ,'hourarch' =>   $this->input->get_post('hourarch', TRUE)
                ,'dayarch' =>   $this->input->get_post('dayarch', TRUE)
                ,'totalarch' =>   $this->input->get_post('totalarch', TRUE)
                ,'iserror' =>   $this->input->get_post('iserror', TRUE)
                ,'logmessage' =>   $this->input->get_post('logmessage', TRUE)
                ,'starttime' =>   $this->input->get_post('starttime', TRUE)
                ,'endtime' =>   $this->input->get_post('endtime', TRUE)
            );
            $tpq_result = $this->m_tpq_result->setRow($data);
            print json_encode($tpq_result);
    }
    function newRow() {
            log_message('debug', 'TPQ_result.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpq_resultid' =>  $this->input->get_post('tpq_resultid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'textresult' =>   $this->input->get_post('textresult', TRUE)
                ,'momentarch' =>   $this->input->get_post('momentarch', TRUE)
                ,'hourarch' =>   $this->input->get_post('hourarch', TRUE)
                ,'dayarch' =>   $this->input->get_post('dayarch', TRUE)
                ,'totalarch' =>   $this->input->get_post('totalarch', TRUE)
                ,'iserror' =>   $this->input->get_post('iserror', TRUE)
                ,'logmessage' =>   $this->input->get_post('logmessage', TRUE)
                ,'starttime' =>   $this->input->get_post('starttime', TRUE)
                ,'endtime' =>   $this->input->get_post('endtime', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpq_result= $this->m_tpq_result->newRow($instanceid,$data);
            $return = $tpq_result;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPQ_result.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpq_result = $this->m_tpq_result->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpq_result
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'textresult', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpq_result= $this->m_tpq_result->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpq_result= $this->m_tpq_result->getRows($sort);
                }
            }else{
              $tpq_result= $this->m_tpq_result->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpq_result
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPQ_result.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'textresult', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpq_result= $this->m_tpq_result->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpq_result
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPQ_result.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'textresult', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpq_result= $this->m_tpq_result->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpq_result
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPQ_result.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpq_resultid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpq_result->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tpq_result', 'm_tpq_result');
    }
}
?>