<?php
	 class C_tplt_bdevices extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLT_BDEVICES.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLT_BDEVICES.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tplt_bdevicesid' =>  $this->input->get_post('tplt_bdevicesid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'thenode' =>   $this->input->get_post('thenode', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
                ,'thephone' =>   $this->input->get_post('thephone', TRUE)
                ,'addr' =>   $this->input->get_post('addr', TRUE)
                ,'devtype' =>   $this->input->get_post('devtype', TRUE)
                ,'shab' =>   $this->input->get_post('shab', TRUE)
                ,'devgrp' =>   $this->input->get_post('devgrp', TRUE)
                ,'theschema' =>   $this->input->get_post('theschema', TRUE)
                ,'theserver' =>   $this->input->get_post('theserver', TRUE)
                ,'nplock' =>   $this->input->get_post('nplock', TRUE)
                ,'connected' =>   $this->input->get_post('connected', TRUE)
            );
            $tplt_bdevices = $this->m_tplt_bdevices->setRow($data);
            print json_encode($tplt_bdevices);
    }
    function newRow() {
            log_message('debug', 'TPLT_BDEVICES.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tplt_bdevicesid' =>  $this->input->get_post('tplt_bdevicesid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'thenode' =>   $this->input->get_post('thenode', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
                ,'thephone' =>   $this->input->get_post('thephone', TRUE)
                ,'addr' =>   $this->input->get_post('addr', TRUE)
                ,'devtype' =>   $this->input->get_post('devtype', TRUE)
                ,'shab' =>   $this->input->get_post('shab', TRUE)
                ,'devgrp' =>   $this->input->get_post('devgrp', TRUE)
                ,'theschema' =>   $this->input->get_post('theschema', TRUE)
                ,'theserver' =>   $this->input->get_post('theserver', TRUE)
                ,'nplock' =>   $this->input->get_post('nplock', TRUE)
                ,'connected' =>   $this->input->get_post('connected', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tplt_bdevices= $this->m_tplt_bdevices->newRow($instanceid,$data);
            $return = $tplt_bdevices;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLT_BDEVICES.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tplt_bdevices = $this->m_tplt_bdevices->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tplt_bdevices
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
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tplt_bdevices= $this->m_tplt_bdevices->getRowsByInstance($instanceid,$sort);
                }else{
                    $tplt_bdevices= $this->m_tplt_bdevices->getRows($sort);
                }
            }else{
              $tplt_bdevices= $this->m_tplt_bdevices->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_bdevices
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLT_BDEVICES.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tplt_bdevices= $this->m_tplt_bdevices->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_bdevices
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
        log_message('debug', 'TPLT_BDEVICES.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tplt_bdevices= $this->m_tplt_bdevices->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tplt_bdevices
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
        log_message('debug', 'TPLT_BDEVICES.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tplt_bdevicesid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tplt_bdevices->deleteRow($tempId);
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
        $this->load->model('M_tplt_bdevices', 'm_tplt_bdevices');
    }
}
?>