<?php
	 class C_bpc_info extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'bpc_info.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'bpc_info.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'bpc_infoid' =>  $this->input->get_post('bpc_infoid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
            );
            $bpc_info = $this->m_bpc_info->setRow($data);
            print json_encode($bpc_info);
    }
    function newRow() {
            log_message('debug', 'bpc_info.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'bpc_infoid' =>  $this->input->get_post('bpc_infoid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $bpc_info= $this->m_bpc_info->newRow($instanceid,$data);
            $return = $bpc_info;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'bpc_info.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $bpc_info = $this->m_bpc_info->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $bpc_info
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
                    $bpc_info= $this->m_bpc_info->getRowsByInstance($instanceid,$sort);
                }else{
                    $bpc_info= $this->m_bpc_info->getRows($sort);
                }
            }else{
              $bpc_info= $this->m_bpc_info->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $bpc_info
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'bpc_info.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
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
            $bpc_info= $this->m_bpc_info->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $bpc_info
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
        log_message('debug', 'bpc_info.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
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
            $bpc_info= $this->m_bpc_info->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $bpc_info
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
        log_message('debug', 'bpc_info.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('bpc_infoid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_bpc_info->deleteRow($tempId);
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
        $this->load->model('M_bpc_info', 'm_bpc_info');
    }
}
?>